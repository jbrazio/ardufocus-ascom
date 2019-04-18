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
namespace Common.Config.Storage
{
    public interface IConfigStorage
    {
        string ProfileName { get; set; }

        void Open();

        string ReadStringFromProfile(string Key);
        string ReadStringFromProfile(string Key, string DefaultValue);
        string ReadStringFromProfile(string Key, string Folder, string DefaultValue);

        int ReadIntFromProfile(string Key);
        int ReadIntFromProfile(string Key, int DefaultValue);
        int ReadIntFromProfile(string Key, string Folder, int DefaultValue);

        uint ReadUIntFromProfile(string Key);
        uint ReadUIntFromProfile(string Key, uint DefaultValue);
        uint ReadUIntFromProfile(string Key, string Folder, uint DefaultValue);

        bool ReadBoolFromProfile(string Key);
        bool ReadBoolFromProfile(string Key, bool DefaultValue);
        bool ReadBoolFromProfile(string Key, string Folder, bool DefaultValue);

        void WriteStringToProfile(string Key, string Value);
        void WriteStringToProfile(string Key, string Value, string Folder);
    }
}
