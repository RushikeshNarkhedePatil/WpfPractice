   M S B A M L   `   `   `  ????F  BPracticeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PracticeWPFPracticeWPF  5   	   !    PracticeWPF.ControlTemplete   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PracticeWPF     5   	     ? Title$  ControlTemplete??5   	   $	??450??6!   $	??800??6.    ? 	Resources 5	         ButtonTemplate ?? 
TargetType A?Name ?? 
StartPoint ?? EndPoint ? Offset ? Color ?? Triggers	 P? Property
 P? Value ?? 
TargetName ?? Property ?? Value ?? ScaleX ?? ScaleY ?? CenterX ?? CenterY??%?  &	        ?? 5
   
   " ??61   .R?5      ? .+?5      A? $ ButtonEllipse??6   $	??100??61   $	??150??6>   ??5      ?? 5      $ 0,0.2&?6.   $ 0.2,1.4&?6A   .??5      ? $ 0Q?6+   $	 Red??66   ? 5      $ 1Q?6+   $ Orange??66   5      5      ?? 5      #??z??6#   $??Center=?5      $??Center=?6/   5       5      P? 5      	 ?@J?IsMouseOver$

 True??63   . ?5      ?? $ ButtonEllipse??6    ? ?? 5      ?? 5      $ 0,0.2&?62   $ 0.2,1.4&?6G   .??5   "   ? $ 0Q?6/   $ YellowGreen??6<   ? 5   "   $ 1Q?6/   $
 Gold??6<   5       5"      5#      P? 5%      	 ? ??$

 True??61   . ?5&      ??  ? z? 5'      ?? 5(      $	 0.8Q?6-   $	 0.8Q?6<   $ 0Q?5)      $ 0Q?6'   5+      ?? 5,       ?@J?RenderTransformOrigin$ 0.5,0.5&?6@   5-      50      51      .??52      ?? .+?53   
   ?? $??Round Button!??6   #??[  6)   $	??150??6T   $??50q?6`   ?? 54   
   $??Default Button!??6   $??40??6-   $	??150??6;   $??5q?6I   55      56      