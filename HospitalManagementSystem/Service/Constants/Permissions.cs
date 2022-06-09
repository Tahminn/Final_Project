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
        public static class Doctors
        {
            public const string View = "Permissions.Doctors.View";
            public const string Create = "Permissions.Doctors.Create";
            public const string Edit = "Permissions.Doctors.Edit";
            public const string Delete = "Permissions.Doctors.Delete";
        }
        public static class Nurses
        {
            public const string View = "Permissions.Nurses.View";
            public const string Create = "Permissions.Nurses.Create";
            public const string Edit = "Permissions.Nurses.Edit";
            public const string Delete = "Permissions.Nurses.Delete";
        }
        public static class Receptionists
        {
            public const string View = "Permissions.Receptionists.View";
            public const string Create = "Permissions.Receptionists.Create";
            public const string Edit = "Permissions.Receptionists.Edit";
            public const string Delete = "Permissions.Receptionists.Delete";
        }
    }
}