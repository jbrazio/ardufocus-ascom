/**
* ASCOM.Ardufocus.Focuser - The most accurate Open Source focus controller
* Copyright (C) 2016-2019 João Brázio [joao@brazio.org]
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*
*/
using System;

namespace Common.Config.Storage
{
    public class ASCOMProfile : IConfigStorage
    {
        private ASCOM.Utilities.Profile Profile;
        public string ProfileName { get; set; }

        public void Open()
        {
            Profile = new ASCOM.Utilities.Profile();
        }

        public string ReadStringFromProfile(string Key)
        {
            return Profile.GetValue(ProfileName, Key);
        }

        public string ReadStringFromProfile(string Key, string DefaultValue)
        {
            string str = Profile.GetValue(ProfileName, Key);
            return (str.Length == 0) ? DefaultValue : str;
        }

        public string ReadStringFromProfile(string Key, string Folder, string DefaultValue)
        {
            string str = Profile.GetValue(ProfileName, Key, Folder);
            return (str.Length == 0) ? DefaultValue : str;
        }

        public int ReadIntFromProfile(string Key)
        {
            return Convert.ToInt32(ReadStringFromProfile(Key));
        }

        public int ReadIntFromProfile(string Key, int DefaultValue)
        {
            string str = ReadStringFromProfile(Key);
            return (str.Length == 0) ? DefaultValue : Convert.ToInt32(str);
        }

        public int ReadIntFromProfile(string Key, string Folder, int DefaultValue)
        {
            string str = ReadStringFromProfile(Key, Folder, null);
            return (str.Length == 0) ? DefaultValue : Convert.ToInt32(str);
        }

        public uint ReadUIntFromProfile(string Key)
        {
            return Convert.ToUInt32(ReadStringFromProfile(Key));
        }

        public uint ReadUIntFromProfile(string Key, uint DefaultValue)
        {
            string str = ReadStringFromProfile(Key);
            return (str.Length == 0) ? DefaultValue : Convert.ToUInt32(str);
        }

        public uint ReadUIntFromProfile(string Key, string Folder, uint DefaultValue)
        {
            string str = ReadStringFromProfile(Key, Folder, null);
            return (str.Length == 0) ? DefaultValue : Convert.ToUInt32(str);
        }

        public bool ReadBoolFromProfile(string Key)
        {
            return Convert.ToBoolean(ReadStringFromProfile(ProfileName, Key));
        }

        public bool ReadBoolFromProfile(string Key, bool DefaultValue)
        {
            string str = ReadStringFromProfile(Key);
            return (str.Length == 0) ? DefaultValue : Convert.ToBoolean(str);
        }

        public bool ReadBoolFromProfile(string Key, string Folder, bool DefaultValue)
        {
            string str = ReadStringFromProfile(Key, Folder, null);
            return (str.Length == 0) ? DefaultValue : Convert.ToBoolean(str);
        }

        public void WriteStringToProfile(string Key, string Value)
        {
            Profile.WriteValue(ProfileName, Key, Value);
        }

        public void WriteStringToProfile(string Key, string Value, string Folder)
        {
            Profile.WriteValue(ProfileName, Key, Value, Folder);
        }
    }
}
