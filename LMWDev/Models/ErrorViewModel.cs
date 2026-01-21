using System;

namespace LMWDev.Models
{
	public class ErrorViewModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public bool Meta { get; set; } = false;
        public bool ShouldNotBeIndexed { get; set; } = false;

    }
}
