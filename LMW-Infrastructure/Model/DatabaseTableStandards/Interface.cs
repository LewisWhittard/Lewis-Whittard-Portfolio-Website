﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMW_Infrastructure.Model
{
	public interface IDatabaseTableStandards
	{
		public int ID { get; set; }
		public bool Inactive { get; set; }
		public bool Deleted { get; set; }
	}
}