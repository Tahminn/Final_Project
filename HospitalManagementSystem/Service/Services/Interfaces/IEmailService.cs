﻿using Service.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IEmailService
    {
        Task RegisterEmail(RegisterDTO registerDTO, string link);

        Task ConfirmEmail(string userId, string token);
    }
}
