using Ardalis.SmartEnum;

namespace Flx.Domain.Identity.Enums
{
    public class RoleEnum : SmartEnum<RoleEnum>
    {
        public static readonly RoleEnum None = new(nameof(None), 0, "None");
        public static readonly RoleEnum SuperAdmin = new(nameof(SuperAdmin), 1, "Super Administrator");
        public static readonly RoleEnum Admin = new(nameof(Admin), 2, "Administrator");
        public static readonly RoleEnum Student = new(nameof(Student), 3, "Student");
        public string UIName { get; set; }

        public RoleEnum(string name, int value, string uiName) : base(name, value)
        {
            this.UIName = uiName;
        }

        public RoleEnum() : this("None", 0, "None")
        {
        }
    }
}
