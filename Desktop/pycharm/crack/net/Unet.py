import torch
import torch.nn as nn
import torch.nn.functional as F
import torch.optim as optimi
import numpy as np


class UNet(nn.Module):
    def __init__(self, in_channels, output_channels):
        super(UNet, self).__init__()

        self.down1 = self.down(in_channels, 64, kernel_size = 3)

        self.mxp1 = nn.MaxPool2d(kernel_size = 2)

        self.down2 = self.down(64, 128, kernel_size = 3)

        self.mxp2 = nn.MaxPool2d(kernel_size = 2)

        self.down3 = self.down(128, 256, kernel_size = 3)

        self.mxp3 = nn.MaxPool2d(kernel_size = 2)

        self.down4 = self.down(256, 512, kernel_size = 3)

        self.mxp4 = nn.MaxPool2d(kernel_size = 2)

        self.bottom = nn.Sequential(
                            torch.nn.Conv2d(in_channels = 512, out_channels = 1024, kernel_size = 3 ),
                            torch.nn.ReLU(),
                            torch.nn.BatchNorm2d(1024),
                            torch.nn.Conv2d(in_channels = 1024, out_channels = 1024, kernel_size = 3,),
                            torch.nn.ReLU(),
                            torch.nn.BatchNorm2d(1024),
                            torch.nn.ConvTranspose2d(in_channels = 1024, out_channels = 512, kernel_size = 3, stride = 2, padding = 1, output_padding = 1)
                            )

        self.up1 = self.up(1024, 512, 256)

        self.up2 = self.up(512, 256, 128)

        self.up3 = self.up(256, 128, 64)

        self.final_layer = self.final(128, 64, out_channels = output_channels)




    def down(self, in_channels, out_channels, kernel_size = 3):
        stage = nn.Sequential(
            nn.Conv2d(in_channels = in_channels, out_channels = out_channels, kernel_size = kernel_size, ),
            nn.ReLU(),
            nn.BatchNorm2d(out_channels),
            nn.Conv2d(in_channels = out_channels, out_channels = out_channels, kernel_size = kernel_size),
            nn.ReLU(),
            nn.BatchNorm2d(out_channels),
        )
        return stage


    def up(self, in_channels, mid_channels, out_channels, kernel_size = 3):
        stage = nn.Sequential(
            nn.Conv2d(in_channels = in_channels, out_channels = mid_channels, kernel_size = kernel_size),
            nn.ReLU(),
            nn.BatchNorm2d(mid_channels),
            nn.Conv2d(in_channels = mid_channels, out_channels = mid_channels, kernel_size = kernel_size),
            nn.ReLU(),
            nn.BatchNorm2d(mid_channels),
            nn.ConvTranspose2d(in_channels = mid_channels, out_channels = out_channels, kernel_size = 3, stride = 2, padding = 1, output_padding = 1),
        )
        return stage


    def final(self, in_channels, mid_channels, out_channels, kernel_size=3):
        layers = nn.Sequential(
            nn.Conv2d(kernel_size = kernel_size, in_channels = in_channels, out_channels = mid_channels),
            nn.ReLU(),
            nn.BatchNorm2d(mid_channels),
            nn.Conv2d(kernel_size = kernel_size, in_channels = mid_channels, out_channels = mid_channels),
            nn.ReLU(),
            nn.BatchNorm2d(mid_channels),
            nn.Conv2d(kernel_size = kernel_size, in_channels = mid_channels, out_channels = out_channels, padding=1),
            nn.ReLU(),
            nn.BatchNorm2d(out_channels),
        )
        return layers


    def crop_and_concat(self, upsampled, bypass, crop = False):
        #copy from torch
        if crop:
            c = (bypass.size()[2] - upsampled.size()[2]) // 2
            bypass = F.pad(bypass, [-c, -c, -c, -c])
        return torch.cat((upsampled, bypass), 1)


    def forward(self, input):

        x = self.down1(input)
        feature_map1 = x
        x = self.mxp1(x)

        x = self.down2(x)
        feature_map2 = x
        x = self.mxp2(x)

        x = self.down3(x)
        feature_map3 = x
        x = self.mxp3(x)

        x = self.down4(x)
        feature_map4 = x
        x = self.mxp4(x)

        x = self.bottom(x)

        x = self.crop_and_concat(x, feature_map4, True)


        x = self.up1(x)

        x = self.crop_and_concat(x, feature_map3, True)

        x = self.up2(x)

        x = self.crop_and_concat(x, feature_map2, True)

        x = self.up3(x)

        x = self.crop_and_concat(x, feature_map1, True)

        x = self.final_layer(x)

        return x



if __name__ == "__main__":
    """
    testing
    """


   model = UNet(1, 2)
    x = torch.rand(1, 1, 572, 572)
    out = model(x)
    loss = torch.sum(out)
    loss.backward()



