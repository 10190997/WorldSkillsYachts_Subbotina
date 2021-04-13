﻿using System;
using System.Collections.Generic;
using System.Linq;
using WorldSkillsYachts.Utils;

namespace WorldSkillsYachts.Models
{
    public partial class User
    {
        public static int PasswordNotChanged(User user)
        {
            if (user.PasswordChanged == null)
                user.PasswordChanged = user.RegisteredDate;
            return DateTime.Today.Subtract((DateTime)user.PasswordChanged).Days;
        }

        public static void CheckUsers()
        {
            List<User> users = AppData.db.Users.ToList();
            foreach (var u in users)
            {
                if (u.LastLogin == null)
                    u.LastLogin = u.RegisteredDate;
                if (DateTime.Today.Subtract((DateTime)u.LastLogin).Days > 30)
                {
                    u.IsBlocked = true;
                    AppData.db.SaveChanges();
                }
            }
        }
    }
}