   M S B A M L   `   `   `  ���� E  AProjectSky, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ProjectSky.ViewsProjectSky.Views  =#clr-namespace:ProjectSky.ViewModelsProjectSky.ViewModels  1clr-namespace:ProjectSky.CoreProjectSky.Core  %    ProjectSky.Views.PokeEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:ProjectSky.Views     2vm#clr-namespace:ProjectSky.ViewModels     .coreclr-namespace:ProjectSky.Core     S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  -     >�Name$  PokemonEditor��$	��518��$	��998�� � 	Resources     BooleanToVisibilityConverter#   ProjectSky.Core.MethodArgType  MethodArgType    ProjectSky.Core.ItemToPlib  
ItemToPlib#   ProjectSky.Core.DesiredValues  DesiredValues(   "ProjectSky.ViewModels.EvoViewModel  EvoViewModel��%K   &	        &	      &	 
     &	      &	      ��         .��� .+��� $��Loading... Please Wait...��$��Center=�$��Center=�  Gill#��[ $��50(�
�������y��� *	!IsLoaded+ �� 	Converter# [  &   HandyControl.Controls.TabControl  ���	#FF202020��Z� y��� *
IsLoaded+# [  .@�#  HandyControl.Controls.TabItem  $��Stats��.��� ���#252525 � ColumnDefinitions �� $��* ��� $��* � � RowDefinitions �� $��75 ��� $��* ��� $��* �.+��� $��0��$��0��$��2��$��Center=�$��Center=�
�������  GillBold#��[ $��50(����� *
PokeName+�� $��1��$��0�� �� CornerRadius$ 5�����#202020$��5q�._��  �� $��* ��� $��* ��� $��* ��� $��* � �� $��60 ��� $��* ��� $��* ��� $��* ��� $��20 �.+��� $��0��$��0��$��4��#��[ $��30(�
�������$��
BASE STATS��$��Center=�$��Center=��� $��1��$��0��#��[ $��15(�
�������$	��HP ��$��Right=�$��Center=��� $��2��$��0��#��[ $��15(�
�������$
��ATK ��$��Right=�$��Center=��� $��3��$��0��#��[ $��15(�
�������$
��DEF ��$��Right=�$��Center=��� $��1��$��3��#��[ $��15(�
�������$
�� SPA��$
��Left=�$��Center=��� $��2��$��3��#��[ $��15(�
�������$�� SPD ��$
��Left=�$��Center=��� $��3��$��3��#��[ $��15(�
�������$�� SPE ��$
��Left=�$��Center=��� $��4��$��3��#��[ $��15(�
�������$
��Left=�$��Center=����� *)'CurrentSpecies.EntryInfo.base_stats.BST+�� $��4��$��2��#��[ $��15(�
�������$�� BST ��$��Right=�$��Center=�)  #HandyControl.Controls.NumericUpDown  $��1��$��1�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��   Minimum$ 1Q�   Maximum$	 255Q�   Value �� *(&CurrentSpecies.EntryInfo.base_stats.HP+  $��1��$��2�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 1Q�$	 255Q� �� *)'CurrentSpecies.EntryInfo.base_stats.SPA+  $��2��$��1�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 1Q�$	 255Q� �� *)'CurrentSpecies.EntryInfo.base_stats.ATK+  $��2��$��2�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 1Q�$	 255Q� �� *)'CurrentSpecies.EntryInfo.base_stats.SPD+  $��3��$��1�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 1Q�$	 255Q� �� *)'CurrentSpecies.EntryInfo.base_stats.DEF+  $��3��$��2�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 1Q�$	 255Q� �� *)'CurrentSpecies.EntryInfo.base_stats.SPE+�� $��2��$��0��$ 5�����#202020$��5q�._��  �� $��* ��� $��* ��� $��* ��� $��* � �� $��60 ��� $��* ��� $��* ��� $��* ��� $��20 �.+��� $��0��$��0��$��4��#��[ $��30(�
�������$��	EV YIELDS��$��Center=�$��Center=��� $��1��$��0��#��[ $��15(�
�������$	��HP ��$��Right=�$��Center=��� $��2��$��0��#��[ $��15(�
�������$
��ATK ��$��Right=�$��Center=��� $��3��$��0��#��[ $��15(�
�������$
��DEF ��$��Right=�$��Center=��� $��1��$��3��#��[ $��15(�
�������$
�� SPA��$
��Left=�$��Center=��� $��2��$��3��#��[ $��15(�
�������$�� SPD ��$
��Left=�$��Center=��� $��3��$��3��#��[ $��15(�
�������$�� SPE ��$
��Left=�$��Center=�  $��1��$��1�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 0Q�$	 255Q� �� *&$CurrentSpecies.EntryInfo.ev_yield.HP+  $��1��$��2�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 0Q�$	 255Q� �� *'%CurrentSpecies.EntryInfo.ev_yield.SPA+  $��2��$��1�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 0Q�$	 255Q� �� *'%CurrentSpecies.EntryInfo.ev_yield.ATK+  $��2��$��2�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 0Q�$	 255Q� �� *'%CurrentSpecies.EntryInfo.ev_yield.SPD+  $��3��$��1�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 0Q�$	 255Q� �� *'%CurrentSpecies.EntryInfo.ev_yield.DEF+  $��3��$��2�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 0Q�$	 255Q� �� *'%CurrentSpecies.EntryInfo.ev_yield.SPE+�� $��1��$��1��$��2��$ 5�����#202020$��5q�._��  �� $��* ��� $��* ��� $��* ��� $��* � �� $��60 ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��20 �.+��� $��0��$��0��$��4��#��[ $��30(�
�������$��
MISC STATS��$��Center=�$��Center=��� $��1��$��0��#��[ $��15(�
�������$��Types ��$��Right=�$��Center=��� $��2��$��0��#��[ $��15(�
�������$��
Abilities ��$��Right=�$��Center=��� $��2��$��4��#��[ $��15(�
�������$�� Egg Groups��$
��Left=�$��Center=��� $��5��$��0��#��[ $��15(�
�������$��
Held Item ��$��Right=�$��Center=�y��� *HasPokeData+# [  �� $��4��$��4��#��[ $��15(�
�������$��	 XP Group��$
��Left=�$��Center=��� $��5��$��4��#��[ $��15(�
�������$�� Held Item %��$
��Left=�$��Center=�y��� *HasPokeData+# [  �� $��6��$��0��#��[ $��15(�
�������$��Gender Group ��$��Right=�$��Center=��� $��6��$��4��#��[ $��15(�
�������$�� Gender Ratio��$
��Left=�$��Center=��� $��7��$��0��#��[ $��15(�
�������$��Friendship ��$��Right=�$��Center=��� $��7��$��4��#��[ $��15(�
�������$�� Catch Rate��$
��Left=�$��Center=��� $��8��$��4��#��[ $��15(�
�������$�� Hatch Cycles��$
��Left=�$��Center=�$  HandyControl.Controls.ComboBox  $��1��$��1�����#1F1F1F���#252525$	��120��$��35��	 �� SelectedIndex	 �� *!CurrentSpecies.EntryInfo.type_1+.@��� $��Normal���� $��Fighting���� $��Flying���� $��Poison���� $��Ground���� $
��Rock���� $	��Bug���� $��Ghost���� $��Steel���� $
��Fire���� $��Water���� $��Grass���� $��Electric���� $��Psychic���� $	��Ice���� $��Dragon���� $
��Dark���� $��Fairy��  $��1��$��2�����#1F1F1F���#252525$	��120��$��35��	 �� *!CurrentSpecies.EntryInfo.type_2+.@��� $��Normal���� $��Fighting���� $��Flying���� $��Poison���� $��Ground���� $
��Rock���� $	��Bug���� $��Ghost���� $��Steel���� $
��Fire���� $��Water���� $��Grass���� $��Electric���� $��Psychic���� $	��Ice���� $��Dragon���� $
��Dark���� $��Fairy��  $��2��$��1�����#1F1F1F���#252525$	��120��$��35������ 
 �� Current �� Source# Z
  �� Path$ Properties[abilities]�	 �� *$"CurrentSpecies.EntryInfo.ability_1+���� .R�$�   $��2��$��2�����#1F1F1F���#252525$	��120��$��35��	 �� *&$CurrentSpecies.EntryInfo.egg_group_1+.@��� $
��None���� $��Monster���� $��Water-1���� $	��Bug���� $��Flying���� $��Field���� $��Fairy���� $��Grass���� $��	Humanlike���� $��Water-3���� $��Mineral���� $��	Amorphous���� $��Water-2���� $��Ditto���� $��Dragon���� $��Undiscovered��  $��3��$��1�����#1F1F1F���#252525$	��120��$��35������ # Z
 $ Properties[abilities]�	 �� *$"CurrentSpecies.EntryInfo.ability_2+���� .R�$�   $��3��$��2�����#1F1F1F���#252525$	��120��$��35��	 �� *&$CurrentSpecies.EntryInfo.egg_group_2+.@��� $
��None���� $��Monster���� $��Water-1���� $	��Bug���� $��Flying���� $��Field���� $��Fairy���� $��Grass���� $��	Humanlike���� $��Water-3���� $��Mineral���� $��	Amorphous���� $��Water-2���� $��Ditto���� $��Dragon���� $��Undiscovered��  $��4��$��1�����#1F1F1F���#252525$	��120��$��35������ # Z
 $ Properties[abilities]�	 �� *)'CurrentSpecies.EntryInfo.ability_hidden+���� .R�$�   $��4��$��2�����#1F1F1F���#252525$	��120��$��35��	 �� *$"CurrentSpecies.EntryInfo.xp_growth+.@��� $��Medium Fast���� $��Erratic���� $��Fluctuating���� $��Medium Slow���� $
��Fast���� $
��Slow��  $��5��$��1�����#1F1F1F���#252525$��Center=�$��Center=� �� DisplayMemberPath$ DisplayName�� �� SelectedValuePath$ DevName��$	��120��$��35������ *ItemsComboBoxItems+ �� SelectedValue �� *HeldItemDevName+y��� *HasPokeData+# [  ���� .R�$�   $��6��$��1�����#1F1F1F���#252525$	��120��$��35��	 �� *'%CurrentSpecies.EntryInfo.gender.group+.@��� $��Male/Female���� $��	Male Only���� $��Female Only���� $��
Genderless��  $��5��$��2�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 1Q�$	 100Q� �� *1/CurrentSpecies.PokeDataInfo.bringItem.bringRate+y��� *HasPokeData+# [    $��6��$��2�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 1Q�$	 100Q� �� *'%CurrentSpecies.EntryInfo.gender.ratio+  $��7��$��1�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 1Q�$	 255Q� �� **(CurrentSpecies.EntryInfo.base_friendship+  $��7��$��2�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 1Q�$	 100Q� �� *%#CurrentSpecies.EntryInfo.catch_rate+  $��8��$��2�����#1F1F1F���#252525
�������$��Center=�$��Center=�$��Center=�$��Center=�$	��120��$��35��$ 1Q�$	 255Q� �� **(CurrentSpecies.EntryInfo.egg_hatch_steps+�� $��9��$��0��$��Is Present?�����#1F1F1F���#252525$��Center=� d� 	IsChecked �� *%#CurrentSpecies.EntryInfo.is_present+  $��Moves��.���  �� $��* ��� $��* ��� $��* � �� $��75 ��� $��* �.+��� $��0��$��0��$��3��$��Center=�$��Center=�$��50(�
�������#��[ ���� *
PokeName+� $��1��$��0��$��2�����#202020$��5q� �� $��35 ��� $��* � �� $	��320 ��� $��* ��� $��* �.+��� $��0��$��1��$��Add Move��$	��165��$��30��$��11(���Z� ���� *AddMoveCommand+�� $��0��$��2��$��Remove Move��$	��165��$��30��$��11(���Z� ���� *RemoveMoveCommand+�� $��1��$��3��.����  �� Orientation$ Vertical=�.+��� ���� *(&CurrentSpecies.EntryInfo.levelup_moves+���� .R��� $ 
Horizontal=�$��Center=�$��5q�.+�  $ 1Q�$	 253Q�$��0 0 5 0q�$��75����Z�  �� *level+  $	��525��$��5 0 0 0q���Z� ���� # Z
 $ Properties[moves]�	 �� *move+ �� Mode$ TwoWay=����� .R�$� �� $��1��$��2�����#202020$��5q�.���� $ Vertical=�.+��� ���� *TMComboBoxItems+����  �� DataType1	   +ProjectSky.ViewModels.CheckBoxItemViewModel" 	 .R��� ���� *Value+ �� *	IsChecked+���� $' !DataContext.ToggleCheckBoxCommand� �� RelativeSource �� *FindAncestor+ �� AncestorType%
   ProjectSky.Views.PokeEditorView" 
 ����   $��
Evolutions��.���  �� $��75 ��� $��* �.+��� $��0��$��0��$��3��$��Center=�$��Center=�$��50(�
�������#��[ ���� *
PokeName+� $��1��$��0��$��2�����#202020$��5q� �� $��35 ��� $��* � �� $	��640 ��� $��* ��� $��* �.+��� $��0��$��1��$��Add Evo��$	��165��$��30��$��11(���Z� ���� *AddEvoCommand+�� $��0��$��2��$��
Remove Evo��$	��165��$��30��$��11(���Z� ���� *RemoveEvoCommand+�� $��1��$��3��.���� $ Vertical=�.+��� ���� *#!CurrentSpecies.EntryInfo.evo_data+���� .R��� $ 
Horizontal=�$��Center=�$��5q�.+�    Name$ ConditionComboBox��$ Method��$ MethodID��$	��190��$��0 0 5 0q����� # [ $ 
EvoMethods� �� *	condition+  -   $	��190��$��0 0 5 0q���`�  `� 	Converter# [ .1���  �� ElementName$ ConditionComboBox��$ SelectedValue��� # [ $ 
EvoMethods��� # [ $ EvoArgs�����  �� 
TargetType"   �� BasedOn 1  +HandyControl.Themes.StaticResourceExtension  *ComboBoxExtend+ �� Triggers ��  �� Value True �� Binding �� # [ $ ConditionComboBox��$ SelectedValue�.a���  �� Property �@��SelectedIndex �� Value �� $ 	parameter��� 	 False �� # [ $ ConditionComboBox��$ SelectedValue�.a���  �@��SelectedIndex `� # [ .1��� $ 	parameter��� $ ConditionComboBox��$ SelectedValue��� # [ $ 
EvoMethods��� # [ $ EvoArgs��� $ DataContext._plibNew� ��   �� Mode$  FindAncestor=�" 
   $	��190��$��0 0 5 0q� �� *level+y��� *SelectedItem.UsesLevel+$ ConditionComboBox��# [    $	��190��$��0 0 5 0q����� # [ $ SpeciesNames�	 �� *	species+  $	��190��$ 0Q�$ 25Q� �� *form+