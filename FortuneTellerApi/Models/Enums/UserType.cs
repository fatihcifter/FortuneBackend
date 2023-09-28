using System.ComponentModel.DataAnnotations;

namespace FortuneTellerApi.Models
{
    public enum UserType
    {
        None = 0,
        FortuneTeller = 1,
        Editor = 2,
        Admin = 666,      
    }
}
