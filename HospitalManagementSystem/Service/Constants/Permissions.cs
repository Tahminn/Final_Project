namespace Service.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
        }

        public static class Patients
        {
            public const string View = "Permissions.Patients.View";
            public const string Create = "Permissions.Patients.Create";
            public const string Edit = "Permissions.Patients.Edit";
            public const string Delete = "Permissions.Patients.Delete";
        }
    }
}