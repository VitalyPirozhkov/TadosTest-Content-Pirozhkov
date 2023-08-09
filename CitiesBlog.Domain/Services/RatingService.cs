﻿using CitiesBlog.Domain.Entity;
using CitiesBlog.Domain.Exceptions;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services
{
    public class RatingService : IDomainService
    {
        public static void Rate(Content content, User user, int value)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));
            if(user == null)
                throw new ArgumentNullException(nameof(user));
            if (value < 1 || value > 5)
                throw new ArgumentOutOfRangeException(nameof(value));
            if (content.Ratings.Select(r => r.User == user).Any())//maybe move to content service
                throw new MultipleUserRateException();
            content.Rate(value,user);
        }
    }
}
