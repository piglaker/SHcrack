import torch
import torch.nn as nn
import torchvision
import torch.nn.functional as F

# not completed yet !

class Decoder(nn.Module):
    def __init__(self, n_classes = 2):
        super(Decoder, self).__init__()
        self.relu = nn.ReLU(inplace=True)
        self.up1 = nn.ConvTranspose2d(512, 512, kernel_size=3, stride=2, padding=1, dialation=1, output_padding=1)
        self.bn1 = nn.BatchNorm2d(512)
        self.up2 = nn.ConvTranspose2d(512, 256, kernel_size=3, stride=2, padding=1, dilation=1, output_padding=1)
        self.bn2 = nn.BatchNorm2d(256)
        self.up3 = nn.ConvTranspose2d(256, 128, kernel_size=3, stride=2, padding=1, dilation=1, output_padding=1)
        self.bn3 = nn.BatchNorm2d(128)
        self.up4 = nn.ConvTranspose2d(128, 64, kernel_size=3, stride=2, padding=1, dilation=1, output_padding=1)
        self.bn4 = nn.BatchNorm2d(64)
        self.up5 = nn.ConvTranspose2d(64, 32, kernel_size=3, stride=2, padding=1, dilation=1, output_padding=1)
        self.bn5 = nn.BatchNorm2d(32)
        self.classifier = nn.Conv2d(32, n_classes, kernel_size = 1)


    def forward(self, x):

        x = self.bn1(self.relu(self.up1(x)))
        x = self.bn2(self.relu(self.up2(x)))
        x = self.bn3(self.relu(self.up3(x)))
        x = self.bn4(self.relu(self.up4(x)))
        x = self.bn5(self.relu(self.up5(x)))
        x = self.classifier(x)

        return x


def build_decoder(num_classes):
    return Decoder(num_classes)

