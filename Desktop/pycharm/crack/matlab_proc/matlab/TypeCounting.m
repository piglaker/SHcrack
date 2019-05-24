function CrackType=TypeCounting(AngleL,AngleR)
%1 horizontal curve       2 vertical crack        
%3 / crack                4 \ crack 
%5 curve crack

Angle=AngleL-AngleR;
if abs(Angle)>22.5
    Type=5;
else
    if (abs(AngleL)<22.5)
        LCrackType=1;
    elseif (abs(AngleL-45)<22.5)
        LCrackType=3;
    elseif (abs(AngleL+45)<22.5)
        LCrackType=4;
    else
        LCrackType=2;
    end
    if (abs(AngleR)<22.5)
        RCrackType=1;
    elseif (abs(AngleR-45)<22.5)
        RCrackType=3;
    elseif (abs(AngleR+45)<22.5)
        RCrackType=4;
    else
        RCrackType=2;
    end
    Type=max(LCrackType,RCrackType);
end
CrackType=Type;