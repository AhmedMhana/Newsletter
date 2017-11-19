using Models.Helper;

namespace Models.Enums
{
    public enum HeardFromResources
    {
        [LocalizedDescription("Advert", typeof(Resources.Resources))]
        Advert = 0,

        [LocalizedDescription("WordOfMouth", typeof(Resources.Resources))]
        WordOfMouth = 1,

        [LocalizedDescription("Other", typeof(Resources.Resources))]
        Other = 2
    }
}
