﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazingQuiz.Shared;

namespace BlazingQuiz.Mobile
{
    public class MobilePlatform : IPlatform
    {
        public bool IsMobileApp => true;

        public bool IsWeb => false;
    }
}