using Model;

namespace VM.Utils
{
    public static class ChampionVMExtension
    {
        public static ChampionVM ToChampionVM(this AddOrEditChampionVM vm)
        {
            var champ = new Champion(vm.EditName, vm.Class, vm.Icon, vm.Image, vm.Bio);
            vm.Skills.ToList().ForEach(s => champ.AddSkill(s.Model));
            vm.Skins.ToList().ForEach(s => champ.AddSkin(s.Model));
            vm.Stats.ToList().ForEach(s => champ.AddCharacteristics(Tuple.Create<string, int>(s.Key, s.Value)));
            return new(champ);
        }
    }
}
