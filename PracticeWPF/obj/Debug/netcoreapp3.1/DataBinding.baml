   M S B A M L   `   `   `  ????F  BPracticeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PracticeWPFPracticeWPF  5   	       PracticeWPF.DataBinding   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PracticeWPF     5   	     ? Title$  DataBinding??5   	   $	??450??6   $	??800??6*   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $	??200 ?6   .+?5   
   ?? -   5        $??lblName??5      $??2q?6   .??6,   _Name:64   ?? 5   
   -   5        $??txtName??5      $??1??6!   $??2q?63   ??6@   ?? *Name+ ?? Mode$ OneWay=??? 5   
   -   5        $??lblAge??5      $??2q?6   $??1??6)   .??66   _Age:6=   ?? 5   
   -   5        $??txtAge??5      $??1??6    $??1??60   $??2q?6=   ??6H   ?? *Age+$ TwoWay=??? 5   
   $??2??6   $??2??6$   .+?5      ?? -   5         ??Name$ btnShow??5      $??_Show...??6&   6;   5      5      5      