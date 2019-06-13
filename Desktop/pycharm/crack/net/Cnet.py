import torch
import torch.nn as nn
import torch.nn.functional as F
import torch.optim as optim
import cv2



class crnet(nn.Module):
    def __init__(self, backbone = 'vgg', pretrained_net_path = '',decoder = 'fcn', n_classes = 2):
        super(crnet, self).__init__()

        #self.backbone = build_backbone(backbone, pretrained_net_path)
        #self.decoder = build_decoder(decoder)

    def forward(self, input):

        x = self.region(input)
        x = self.backbone_piece(x)
        x = self.decoder_piece(x)
        x = self.r.joint_piece(),

        return x

    def region(self, input):
        img = self.tune(input)


        return

    def tune(self, img):
        normal_size = 224
        m, n = int(len(img) / 224), int(len(img[0]) / 224)
        img = cv2.resize(img, (n * normal_size, m * normal_size), interpolation=cv2.INTER_CUBIC)
        return img





