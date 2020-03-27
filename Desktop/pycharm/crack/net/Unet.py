import torch
import torch.nn as nn
import torch.nn.functional as F
import torch.optim as optimi
import numpy as np


class UNet(nn.Module):
    def __init__(self, in_channels, output_channels, block):
        super(UNet, self).__init__()
        """
        
        self.down1 = self.down(in_channels, 64, kernel_size=3)

        self.mxp1 = nn.MaxPool2d(kernel_size=2)

        self.down2 = self.down(64, 128, kernel_size=3)

        self.mxp2 = nn.MaxPool2d(kernel_size=2)

        self.down3 = self.down(128, 256, kernel_size=3)

        self.mxp3 = nn.MaxPool2d(kernel_size=2)

        self.down4 = self.down(256, 512, kernel_size=3)

        self.mxp4 = nn.MaxPool2d(kernel_size=2)
        
        """
        self.inplanes = in_channels

        self.layers = [3, 3, 3, 3, 3]

        self.layer0 = self._make_layer(block, 32, self.layers[0], downsample=False)

        self.layer1 = self._make_layer(block, 64, self.layers[1], downsample=True)

        self.layer2 = self._make_layer(block, 128, self.layers[2], downsample=True)

        self.layer3 = self._make_layer(block, 256, self.layers[3], downsample=True)

        self.layer4 = self._make_layer(block, 512, self.layers[4], downsample=True)

        self.bottom = nn.Sequential(
                            torch.nn.Conv2d(in_channels=512, out_channels=1024, kernel_size=3, padding=1),
                            torch.nn.ReLU(),
                            torch.nn.BatchNorm2d(1024),
                            torch.nn.Conv2d(in_channels=1024, out_channels=512, kernel_size=3, padding=1),
                            torch.nn.ReLU(),
                            torch.nn.BatchNorm2d(512),
                            # torch.nn.ConvTranspose2d(in_channels=1024, out_channels=512, kernel_size=3, stride=2,
                            #                                           padding=1, output_padding = 1)
                            # output = (input - 1) * stride + output_padding - 2 * padding + kernel_size
                            )

        self.up1 = self.up(1024, 512, 256)

        self.up2 = self.up(512, 256, 128)

        self.up3 = self.up(256, 128, 64)

        self.up4 = self.up(128, 64, 32)

        self.final_layer = self.final(64, 32, out_channels=output_channels)
        

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
            nn.Conv2d(in_channels = in_channels, out_channels = mid_channels, kernel_size = kernel_size, padding=1),
            nn.ReLU(),
            nn.BatchNorm2d(mid_channels),
            nn.Conv2d(in_channels = mid_channels, out_channels = mid_channels, kernel_size = kernel_size, padding=1),
            nn.ReLU(),
            nn.BatchNorm2d(mid_channels),
            nn.ConvTranspose2d(in_channels = mid_channels, out_channels = out_channels, kernel_size = 3, stride = 2, padding = 1, output_padding = 1),
        )
        return stage
    
    
    def _make_layer(self, block, planes, blocks, downsample=False):
        layers = []

        layers.append(block(self.inplanes, planes, residual=False))

        self.inplanes = planes

        for i in range(1, blocks):
            layers.append(block(self.inplanes, planes))

        if downsample:
            layers.append(block(self.inplanes, planes, downsample=True))

        return nn.Sequential(* layers)


    def final(self, in_channels, mid_channels, out_channels, kernel_size=3):
        layers = nn.Sequential(
            nn.Conv2d(kernel_size=kernel_size, in_channels=in_channels, out_channels=mid_channels, padding=1),
            nn.ReLU(),
            nn.BatchNorm2d(mid_channels),
            nn.Conv2d(kernel_size=kernel_size, in_channels=mid_channels, out_channels=mid_channels, padding=1),
            nn.ReLU(),
            nn.BatchNorm2d(mid_channels),
            nn.Conv2d(kernel_size=kernel_size, in_channels=mid_channels, out_channels=out_channels, padding=1),
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

        x = self.layer0(input)

        feature_map0 = x

        x = self.layer1(x)

        feature_map1 = x

        x = self.layer2(x)

        feature_map2 = x

        x = self.layer3(x)

        feature_map3 = x

        x = self.layer4(x)

        feature_map4 = x

        x = self.bottom(x)

        x = self.crop_and_concat(x, feature_map4, True)

        x = self.up1(x)

        x = self.crop_and_concat(x, feature_map3, True)

        x = self.up2(x)

        x = self.crop_and_concat(x, feature_map2, True)

        x = self.up3(x)

        x = self.crop_and_concat(x, feature_map1, True)

        x = self.up4(x)

        x = self.crop_and_concat(x, feature_map0, True)

        x = self.final_layer(x)

        return torch.sigmoid(x)


class Residual_Block(nn.Module):
 
    def __init__(self, inplanes, planes, residual=True, downsample=False):
        super(Residual_Block, self).__init__()

        self.conv1 = nn.Conv2d(inplanes, planes, kernel_size=3, stride=1,
                     padding=1, bias=False)
        self.bn1 = nn.BatchNorm2d(planes)

        self.relu = nn.ReLU()

        self.conv2 = nn.Conv2d(planes, planes, kernel_size=3, stride=1,
                     padding=1, bias=False)
        self.bn2 = nn.BatchNorm2d(planes)

        self.residual = residual

        self.downsample = downsample

        self.down = nn.Sequential(
                nn.Conv2d(planes, planes ,
                          kernel_size=3, stride=2, bias=False, padding=1),
                nn.BatchNorm2d(planes),
                nn.ReLU(),
                )


    def forward(self, x):

        residual = x

        out = self.conv1(x)
        out = self.bn1(out)
        out = self.relu(out)

        out = self.conv2(out)
        out = self.bn2(out)

        if self.residual:
            out = out + residual

        out = self.relu(out)

        if self.downsample:
            out = self.down(out)
 
        return out


if __name__ == "__main__":
    """
    testing
    """

    model = UNet(3, 1, Residual_Block)
    x = torch.rand(1, 3, 512, 512)
    out = model(x)
    loss = torch.sum(out)
    loss.backward()

