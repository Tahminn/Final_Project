namespace Service.Constants
{
    public static class PolicyTypes
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
        {
            $"{module}.create",
            $"{module}.view",
            $"{module}.edit",
            $"{module}.delete",
        };
        }

        public static class Patients
        {
            public const string Create = "patients.create";
            public const string View = "patients.view";
            public const string Edit = "patients.edit";
            public const string Delete = "patients.delete";
        }

        public static class Doctors
        {
            public const string Create = "doctors.create";
            public const string View = "doctors.view";
            public const string Edit = "doctors.edit";
            public const string Delete = "doctors.delete";
        }
        public static class Nurses
        {
            public const string Create = "nurses.create";
            public const string View = "nurses.view";
            public const string Edit = "nurses.edit";
            public const string Delete = "nurses.delete";
        }
        public static class Receptionists
        {
            public const string Create = "receptionists.create";
            public const string View = "receptionists.view";
            public const string Edit = "receptionists.edit";
            public const string Delete = "receptionists.delete";
        }
        public static class Operations
        {
            public const string Create = "operations.create";
            public const string View = "operations.view";
            public const string Edit = "operations.edit";
            public const string Delete = "operations.delete";
        }
        public static class Beds
        {
            public const string Create = "beds.create";
            public const string View = "beds.view";
            public const string Edit = "beds.edit";
            public const string Delete = "beds.delete";
        }
        public static class Tests
        {
            public const string Create = "tests.create";
            public const string View = "tests.view";
            public const string Edit = "tests.edit";
            public const string Delete = "tests.delete";
        }
        public static class Bills
        {
            public const string Create = "bills.create";
            public const string View = "bills.view";
            public const string Edit = "bills.edit";
            public const string Delete = "bills.delete";
        }
        public static class Payments
        {
            public const string Create = "payments.create";
            public const string View = "payments.view";
            public const string Edit = "payments.edit";
            public const string Delete = "payments.delete";
        }
    }
}