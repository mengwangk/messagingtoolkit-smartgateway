//===============================================================================
// OSML - Open Source Messaging Library
//
//===============================================================================
// Copyright © TWIT88.COM.  All rights reserved.
//
// This file is part of Open Source Messaging Library.
//
// Open Source Messaging Library is free software: you can redistribute it 
// and/or modify it under the terms of the GNU General Public License version 3.
//
// Open Source Messaging Library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this software.  If not, see <http://www.gnu.org/licenses/>.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MessagingToolkit.SmartGateway.Portal.ViewModels
{
    /// <summary>
    /// View model for outgoing message
    /// </summary>
    public class OutgoingMessageViewModel
    {
        public OutgoingMessageViewModel()
        {
            ScheduledDate = DateTime.Now;
            WapExpiryDate = DateTime.Now;
            WapCreateDate = DateTime.Now;
            WapUrl = "http://";
        }

        [Required(ErrorMessage="Channel is required")]
        public string Channel { get; set; }

        [Required(ErrorMessage="Recipient is required")]
        [Display(Name = "Recipient")]
        public string Recipient { get; set; }

        [Required]
        [Display(Name = "Message Type")]
        public string MessageType { get; set; }
        
        [Required]
        [Display(Name = "Message Format")]
        public string MessageFormat { get; set; }
        
        [Required]
        public string Priority { get; set; }
        
        [Required]
        [Display(Name = "Message Content")]
        public string Message { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Scheduled Send Date")]
        public DateTime ScheduledDate { get; set; }

        [Required]
        [Display(Name = "Message Class")]
        public string MessageClass { get; set; }

        [Display(Name = "Source Port")]
        public int SrcPort {get; set;}

        [Display(Name = "Destination Port")]
        public int DestPort {get; set;}

        [Required]
        [Display(Name = "Status Report")]
        public string StatusReport {get; set;}

        [Display(Name = "WAP Push Message URL")]
        public string WapUrl {get; set;}

        [DataType(DataType.DateTime)]
        [Display(Name = "WAP Push Message Expiry Date")]
        public DateTime WapExpiryDate {get; set;}
        
        [DataType(DataType.DateTime)]
        [Display(Name = "WAP Push Message Creation Date")]
        public DateTime WapCreateDate { get; set;}

        [Display(Name = "WAP Push Message Signal")]
        public string WapSignal {get; set;}        
    }
}