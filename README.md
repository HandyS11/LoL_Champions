# LoL_Champions

## 📝 Purpose

Create a [**MAUI**](https://learn.microsoft.com/en-us/dotnet/maui/) application using **MVVM** to implement a given model.

- Available on Android & IOS
- Work on ViewModel (views are not important)

## 🛠 Languages & tools

![skills](https://skillicons.dev/icons?i=cs,dotnet,visualstudio)

## 🖊️ Versions 

- [.NET 7](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-7)
- [Android API](https://developer.android.com/reference) 33 *(tested)*
- [iOS](https://www.apple.com/ios) 16 *(tested)*

## 📍 Visuals

> Please note that the screenshots from the original app were taken with an Iphone.
> Thoses of the "Clone-app" were taken with an Android with a different resolution.

<details><summary> Main Pages </summary>

| OriginalApp | CloneApp |
| --- | --- |
| <img src="./Documentation/screens/HomePage.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
| <img src="./Documentation/screens/ChampionsPage.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
| <img src="./Documentation/screens/SwipeView.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
| <img src="./Documentation/screens/ChampionDetail1.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
| <img src="./Documentation/screens/ChampionDetail2.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
| <img src="./Documentation/screens/ChampionDetail3.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
</details>

<details><summary> Other Pages </summary>

| OriginalApp | CloneApp |
| --- | --- |
| <img src="./Documentation/screens/AddChampion.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
| <img src="./Documentation/screens/AddSkin.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
| <img src="./Documentation/screens/EditChampion1.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
| <img src="./Documentation/screens/EditChampion2.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
| <img src="./Documentation/screens/NewSkill.PNG" height="750"/> | <img src="./Documentation/screens/thepage.PNG" height="750"/> |
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

---
</details>

<details><summary> ViewModels </summary>

```mermaid
classDiagram

class AppVM {
    +-/NavigateBackCommand : ICommand
    +-/ChampionDetailCommand : ICommand
    +-/AddChampionCommand : ICommand
    +-/EditChampionCommand : ICommand
    +-/DeleteChampionCommand : ICommand
    +-/ChooseImageCommand : ICommand
    +-/ChooseIconCommand : ICommand
    - NavigateBack() Task
    - GoToChampionDetail(ChampionVM vm) Task
    - GoToAddChampion() Task
    - GoToEditChampion(ChampionVM vm) Task
    - DeleteChampion(ChampionVM vm) Task
    - ChooseImage() Task
    - ChooseIcon() Task
}
AppVM --> "1" ChampionManagerVM : ChampionManagerVM
AppVM --> "1" AddOrEditChampionVM : AddOrEditChampionVM

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
    - DeleteChampion(ChampionVM vm) Task
    - EditChampion(ChampionVM vm) Task
    - AddChampion(ChampionVM vm) Task
}
ChampionManagerVM --> "1" ChampionVM : SelectedChampion
ChampionManagerVM --> "*" ChampionVM : Champions

class ChampionVM {
    +/Model : Champion
    +/Name : string
    +/Bio : string
    +/Icon : string
    +/Image : LargeImage
    +/Class : ChampionClass?
}
ChampionVM --> "*" SkillVM : Skills
ChampionVM --> "*" SkinVM : Skins

class SkillVM {
    +/Model : Skill
    +/Name : string
    +/Description : string
    +_/Type : string
}

class SkinVM {
    +/Model : Skin
    +/Name : string
    +/Icon : string
}

class AddOrEditChampionVM {
    +/IsNewChamp : bool
    +/Name : string
    +/Bio : string
    +/Icon : string
    +/Image : LargeImage
    +/Class : ChampionClass?
}
AddOrEditChampionVM --> "1" ChampionVM : VM
AddOrEditChampionVM --> "*" SkillVM : Skills
AddOrEditChampionVM --> "*" SkinVM : Skins
```
</details>

## ✍️ Credits 

* Author: [**Valetin Clergue**](https://github.com/HandyS11)