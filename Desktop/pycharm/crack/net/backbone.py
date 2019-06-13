import torch
import torch.nn as nn
import torchvision
import torch.nn.functional as F


class VGGNet(nn.Module):
    def __init__(self, pretrained_net_path, model='vgg16', requires_grad=True):
        super(VGGNet, self).__init__()
        self.layers = vgg(cfg[model])
        if pretrained_net_path:
            exec("self.load_state_dict(models.%s(pretrained=True).state_dict())" % model)
            """
            load pretrained_vgg
            """

        if not requires_grad:
            for param in super(VGGNet, self).parameters():
                param.requires_grad = False

    def forward(self, x):

        for layer in self.layers[0:len(self.layers)]:
            x = layer(x)
        return x


def vgg(cfg, batch_norm=False):
    layers = []
    in_channels = 3
    for v in cfg:
        if v == 'M':
            layers += [nn.MaxPool2d(kernel_size=2, stride=2)]
        elif v == 'C':
            layers += [nn.MaxPool2d(kernel_size=2, stride=2, ceil_mode=True)]
        else:
            conv2d = nn.Conv2d(in_channels, v, kernel_size=3, padding=1)
            if batch_norm:
                layers += [conv2d, nn.BatchNorm2d(v), nn.ReLU(inplace=True)]
            else:
                layers += [conv2d, nn.ReLU(inplace=True)]
            in_channels = v
    pool5 = nn.MaxPool2d(kernel_size=3, stride=1, padding=1)
    conv6 = nn.Conv2d(512, 1024, kernel_size=3, padding=6, dilation=6)
    conv7 = nn.Conv2d(1024, 1024, kernel_size=1)
    layers += [pool5, conv6,
               nn.ReLU(inplace=True), conv7, nn.ReLU(inplace=True)]
    return layers


cfg = {
    'vgg11': [64, 'M', 128, 'M', 256, 256, 'M', 512, 512, 'M', 512, 512, 'M'],
    'vgg13': [64, 64, 'M', 128, 128, 'M', 256, 256, 'M', 512, 512, 'M', 512, 512, 'M'],
    'vgg16': [64, 64, 'M', 128, 128, 'M', 256, 256, 256, 'M', 512, 512, 512, 'M', 512, 512, 512, 'M'],
    'vgg19': [64, 64, 'M', 128, 128, 'M', 256, 256, 256, 256, 'M', 512, 512, 512, 512, 'M', 512, 512, 512, 512, 'M'],
}


def build_backbone(pretrained_net_path="models/", model_='vgg16', requires_grad_=True):
    return VGGNet(pretrained_net_path= pretrained_net_path, model = model_, requires_grad = requires_grad_)

