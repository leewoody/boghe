﻿/*
* Boghe IMS/RCS Client - Copyright (C) 2010 Mamadou Diop.
*
* Contact: Mamadou Diop <diopmamadou(at)doubango.org>
*	
* This file is part of Boghe Project (http://code.google.com/p/boghe)
*
* Boghe is free software: you can redistribute it and/or modify it under the terms of 
* the GNU General Public License as published by the Free Software Foundation, either version 3 
* of the License, or (at your option) any later version.
*	
* Boghe is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
* without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
* See the GNU General Public License for more details.
*	
* You should have received a copy of the GNU General Public License along 
* with this program; if not, write to the Free Software Foundation, Inc., 
* 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
#if WINRT
using System.Runtime.Serialization;
using Serializable = System.Runtime.Serialization.DataContractAttribute;
#endif

namespace BogheCore.Model
{
    [Serializable]
    [XmlRoot("HistoryAVCallEvent")]
    public class HistoryAVCallEvent : HistoryEvent, IComparable<HistoryAVCallEvent>
    {
        protected DateTime startTime;
        protected DateTime endTime;

        private HistoryAVCallEvent() 
            : this(false, null)
        {
            
        }

        public HistoryAVCallEvent(bool video, String remoteParty)
            : base (video ? MediaType.AudioVideo : MediaType.Audio, remoteParty)
        {
            this.startTime = base.Date;
            this.endTime = base.Date;
        }

        [XmlElement("StartTime")]
        public DateTime StartTime
        {
            get { return this.startTime; }
            set
            {
                this.startTime = value;
                this.OnPropertyChanged("StartTime");
            }
        }

        [XmlElement("EndTime")]
        public DateTime EndTime
        {
            get { return this.endTime; }
            set
            {
                this.endTime = value;
                this.OnPropertyChanged("EndTime");
            }
        }

        public int CompareTo(HistoryAVCallEvent other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            return other.StartTime.CompareTo(this.StartTime);
        }
    }
}
