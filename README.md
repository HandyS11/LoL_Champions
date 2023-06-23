# LoL_Champions

## 📝 Purpose

Create a [**MAUI**](https://learn.microsoft.com/en-us/dotnet/maui/) application using **MVVM** to implement a given model.

- Available on Android & IOS
- Work on ViewModel (views are not important)

## 📊 Features

**Done:**
1. Champion list *+ navigation*
2. Champion detail
3. Caracteristics management
4. Champion management
5. Swipe view *(\<MenuItem\> because of Android problems)*
6. Skills management
7. Skins management

**NotDone:**
- You can't remove a Skin
- You can't edit a Caracteristic

**V2**: [MVVM_Toolkit](https://github.com/HandyS11/LoL_Champions/tree/mvvm_toolkit)

## 🛠 Languages & tools

![skills](https://skillicons.dev/icons?i=cs,dotnet,visualstudio)

## 🖊️ Versions 

- [.NET 7](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7)
- [Android API](https://developer.android.com/reference) 33 *(tested)*
- [iOS](https://www.apple.com/ios) 16 *(tested)*

## 📍 Visuals

> Please note that the screenshots from the original app were taken with a different phone of the CloneApp ones.

<details><summary> Main Pages </summary>

| OriginalApp | CloneApp |
| --- | --- |
| <img src="./Documentation/screens/HomePage.PNG" height="750"/> | <img src="./Documentation/screens/HomePageMine.png" height="750"/> |
| <img src="./Documentation/screens/ChampionsPage.PNG" height="750"/> | <img src="./Documentation/screens/ChampionsPageMine.png" height="750"/> |
| <img src="./Documentation/screens/SwipeView.PNG" height="750"/> | <img src="./Documentation/screens/SwipeViewMine.png" height="750"/> |
| <img src="./Documentation/screens/ChampionDetail1.PNG" height="750"/> | <img src="./Documentation/screens/ChampionDetail1Mine.png" height="750"/> |
| <img src="./Documentation/screens/ChampionDetail2.PNG" height="750"/> | <img src="./Documentation/screens/ChampionDetail2Mine.png" height="750"/> |
| <img src="./Documentation/screens/ChampionDetail3.PNG" height="750"/> | <img src="./Documentation/screens/ChampionDetail3Mine.png" height="750"/> |
| <img src="./Documentation/screens/ChampionSkin.PNG" height="750"/> | <img src="./Documentation/screens/ChampionSkinMine.png" height="750"/> |
</details>

<details><summary> Other Pages </summary>

| OriginalApp | CloneApp |
| --- | --- |
| <img src="./Documentation/screens/AddChampion.PNG" height="750"/> | <img src="./Documentation/screens/AddChampionMine.png" height="750"/> |
| <img src="./Documentation/screens/AddSkin.PNG" height="750"/> | <img src="./Documentation/screens/AddSkinMine.png" height="750"/> |
| <img src="./Documentation/screens/EditChampion1.PNG" height="750"/> | <img src="./Documentation/screens/EditChampion1Mine.png" height="750"/> |
| <img src="./Documentation/screens/EditChampion2.PNG" height="750"/> | <img src="./Documentation/screens/EditChampion2Mine.png" height="750"/> |
| <img src="./Documentation/screens/NewSkill.PNG" height="750"/> | <img src="./Documentation/screens/NewSkillMine.png" height="750"/> |
</details>

## ⚙️ Architecture

> Theses diagrams are not fully accurate and only gave the global idea of the conception.

<details><summary> Models </summary>

```mermaid
classDiagram

class LargeImage{
    +/Base64 : string
}
class Champion{
    +/Name : string
    +/Bio : string
    +/Icon : string
    +/Characteristics : Dictionary(string, int)
    ~ AddSkin(skin : Skin) bool
    ~ RemoveSkin(skin: Skin) bool
    + AddSkill(skill: Skill) bool
    + RemoveSkill(skill: Skill) bool
    + AddCharacteristics(someCharacteristics : params Tuple(string, int)[])
    + RemoveCharacteristics(label : string) bool
    + this(label : string) : int?
}
Champion --> "1" LargeImage : Image
class ChampionClass{
    <<enumeration>>
    Unknown,
    Assassin,
    Fighter,
    Mage,
    Marksman,
    Support,
    Tank,
}
Champion --> "1" ChampionClass : Class
class Skin{
    +/Name : string    
    +/Description : string
    +/Icon : string
    +/Price : float
}
Skin --> "1" LargeImage : Image
Champion "1" -- "*" Skin 
class Skill{
    +/Name : string    
    +/Description : string
}
class SkillType{
    <<enumeration>>
    Unknown,
    Basic,
    Passive,
    Ultimate,
}
Skill --> "1" SkillType : Type
Champion --> "*" Skill
```
</details>

---

> Every **VM** inherits from `BaseViewModel` which implements `INotifyPropertyChanged` and `SetProperty` to notify the view of any changes and setting properties.

<details><summary> ViewModels </summary>

```mermaid
classDiagram

class AppVM {
    +-/NavigateBackCommand : ICommand
    +-/GoToChampionDetailCommand : ICommand
    +-/GoToChampionSkinCommand : ICommand
    +-/GoToAddChampionCommand : ICommand
    +-/GoToEditChampionCommand : ICommand
    +-/GoToAddSkinCommand : ICommand
    +-/GoToEditSkinCommand : ICommand
    +-/GoToAddSkillCommand : ICommand
    +-/GoToEditSkillCommand : ICommand
    +-/DeleteChampionCommand : ICommand
    +-/AddChampionCommand : ICommand
    +-/EditChampionCommand : ICommand
    +-/AddSkinCommand : ICommand
    +-/EditSkinCommand : ICommand
    +-/AddSkillCommand : ICommand
    +-/EditSkillCommand : ICommand
    +-/ChooseImageCommand : ICommand
    +-/ChooseIconCommand : ICommand
    +-/ChooseSkinImageCommand : ICommand
    +-/ChooseSkinIconCommand : ICommand
    - NavigateBack() Task
    - GoToChampionDetail(ChampionVM vm) Task
    - GoToChampionSkin(SkinVM vm) Task
    - GoToAddChampion() Task
    - GoToEditChampion(ChampionVM vm) Task
    - GoToAddSkin() Task
    - GoToEditSkin(SkinVM vm) Task
    - GoToAddSkill() Task
    - GoToEditSkill(SkillVM vm) Task
    - AddChampion(ChampionVM vm) Task
    - EditChampion(ChampionVM vm) Task
    - AddSkin(SkinVM vm) Task
    - EditSkin(SkinVM vm) Task
    - AddSkill(SkillVM vm) Task
    - EditSkill(SkillVM vm) Task
    - ChooseImage() Task
    - ChooseIcon() Task
    - ChooseSkinImage() Task
    - ChooseSkinIcon() Task
}
AppVM --> "1" ChampionManagerVM : ChampionManagerVM
AppVM --> "1" AddOrEditChampionVM : AddOrEditChampionVM
AppVM --> "1" AddOrEditSkillVM : AddOrEditSkillVM
AppVM --> "1" AddOrEditSkinVM : AddOrEditSkinVM

class ChampionManagerVM {
    +/Datamanager : IDataManager
    +/Index : int
    +_/HumanIndex : int
    +_/IsFirstPage : int
    +_/IsLastPage : int
    +/Count : int
    +/NbPages : int
    +-/PreviousPageCommand : ICommand
    +-/NextPageCommand : ICommand
    +-/LoadChampionsCommand : ICommand
    +-/DeleteChampionCommand : ICommand
    +-/EditChampionCommand : ICommand
    +-/AddChampionCommand : ICommand
    - LoadChampions() Task
    - LoadPage(bool) Task
    + DeleteChampion(ChampionVM vm) Task
    + EditChampion(ChampionVM vm) Task
    + AddChampion(ChampionVM vm) Task
}
ChampionManagerVM --> "1" ChampionVM : SelectedChampion
ChampionManagerVM --> "*" ChampionVM : Champions

class ChampionVM {
    +/Model : Champion
    +/Name : string
    +/Bio : string
    +/Icon : string
    +/Image : string
    +/Class : ChampionClass?
    + LoadStats()
    + AddStat()
    + RemoveStat()
    + LoadSkins()
    + AddSkin()
    + RemoveSkin()
    + UpdateSkin(Skin skin)
    + LoadSkills()
    + AddSkill()
    + RemoveSkill()
    + UpdateSkill(Skill skill)
}
ChampionVM --> "*" SkinVM : Skins
ChampionVM --> "*" SkillVM : Skills
ChampionVM --> "1" SkinVM : SelectedSkin
ChampionVM --> "1" SkillVM : SelectedSkill

class SkillVM {
    +/Model : Skill
    +/Name : string
    +/Description : string
    +_/Type : string
}

class SkinVM {
    +/Model : Skin
    +/Name : string
    +/Description : string
    +/Icon : string
    +/Image : string
    +/Price : float
}

class AddOrEditChampionVM {
    +-/AddStatEditCommand : ICommand
    +-/DeleteStatEditCommand : ICommand
    +-/DeleteSkillEditCommand : ICommand
    +/IsNewChamp : bool
    +/EditName : string
    +/RadioButton : string
    +/Stat : String
    +/StatValue : int
    - AddStatEdit()
    - RemoveStatEdit(string key)
    - RemoveSkillEdit(SkillVM skill)
}
AddOrEditChampionVM ..|> ChampionVM

class AddOrEditSkillVM {
    +/IsNewSkill : bool
    +/EditName : string
    +/SkillPicker : TypePicker 
    +/EditDesc : string
    +_/SkillVM : SkillVM
}
AddOrEditSkillVM ..|> SkillVM

class AddOrEditSkinVM {
    +/IsNewSkin : bool
    +/EditName : string
    +_/SkinVM : SkinVM
}
AddOrEditSkinVM ..|> SkinVM
```
</details>

## ⚡️ Known limitations

Due to its youngness *(and ~~maybe~~ certainly because of my lack of knowledge)* the **CollectionView**, **SwapView** and others seems to have been implemented differently through the platforms leading to some issues.

> For exemple this code works on Android but got problems of height on iOS
```xml
<CollectionView ItemsSource="{Binding SomeCollection}"
                SelectionMode="None">
    <CollectionView.ItemsLayout>
        <GridItemsLayout Orientation="Vertical" 
                         Span="2" />
    </CollectionView.ItemsLayout>
                    
    <CollectionView.ItemTemplate>
        <DataTemplate>
            <SomeComponent/>
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>
```

## ✍️ Credits 

* Author: [**Valetin Clergue**](https://github.com/HandyS11)
