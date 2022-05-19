using ViewModels.enums;
using System.ComponentModel;

namespace ViewModels.Builders
{
    public static class CustomerBuilder
    {
        private static readonly EnumConverter _converter = new(typeof(CustomerVM));
        public static void SetGender(this CustomerVM model, Gender gender)
        {
            model.Gender = gender.ToString();
        }

        public static Gender GetGender(this CustomerVM model)
        {
            return (Gender)_converter.ConvertFromString(model.Gender);
        }
    }
}
