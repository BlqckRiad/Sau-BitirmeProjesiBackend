﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginRegisterService.DtoLayer.Dtos
{
    public class UpdateRoleDto
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; } 
        public int UpdatedUserID { get; set; }
    }
}
