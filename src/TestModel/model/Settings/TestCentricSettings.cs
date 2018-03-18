﻿// ***********************************************************************
// Copyright (c) 2018 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System.Drawing;
using NUnit.Engine;

namespace TestCentric.Gui.Model.Settings
{
    /// <summary>
    /// Settings specific to TestCentric. Because we store settings in the
    /// NUnit 3 settings file, we use our own unique prefix to avoid conflicts.
    /// </summary>
    public class TestCentricSettings : SettingsGroup
    {
        public TestCentricSettings(ISettings settings)
             : base(settings, "TestCentric") { }

        public TestTreeSettings TestTree
        {
            get { return new TestTreeSettings(_settings); }
        }

        public RecentProjectsSettings RecentProjects
        {
            get { return new RecentProjectsSettings(_settings); }
        }

        public MiniFormSettings MiniForm
        {
            get { return new MiniFormSettings(_settings); }
        }

        public MainFormSettings MainForm
        {
            get { return new MainFormSettings(_settings); }
        }

        public ErrorDisplaySettings ErrorDisplay
        {
            get { return new ErrorDisplaySettings(_settings); }
        }

        public TextOutputSettings TextOutput
        {
            get { return new TextOutputSettings(_settings); }
        }

        public string DisplayFormat
        {
            get { return GetSetting("DisplayFormat", "Full"); }
            set { SaveSetting("DisplayFormat", value); }
        }

        public bool LoadLastProject
        {
            get { return GetSetting("LoadLastProject", true); }
            set { SaveSetting("LoadLastProject", value); }
        }

        public int SelectedTab
        {
            get { return GetSetting("SelectedTab", 0); }
            set { SaveSetting("SelectedTab", value); }
        }

        public string InitialSettingsPage
        {
            get { return (string)GetSetting("Settings.InitialPage"); }
            set { SaveSetting("Settings.InitialPage", value); } // TODO: Handle null
        }

        public bool ClearResultsOnReload
        {
            get { return GetSetting("ClearResultsOnReload", false); }
            set { SaveSetting("ClearResultsOnReload", value); }
        }

        private static readonly Font DefaultFont = new Font(FontFamily.GenericSansSerif, 8.25f);
        public Font Font
        {
            get { return GetSetting("Font", DefaultFont); }
            set { SaveSetting("Font", value); }
        }

        private static readonly Font DefaultFixedFont = new Font(FontFamily.GenericMonospace, 8.0F);
        public Font FixedFont
        {
            get { return GetSetting("FixedFont", DefaultFixedFont); }
            set { SaveSetting("FixedFont", value); }
        }

        public string ProjectEditorPath
        {
            get { return GetSetting("ProjectEditorPath", "nunit-editor.exe"); }
            set { SaveSetting("ProjectEditorPath", value); } // TODO: Handle null
        }

        public InternalTraceLevel InternalTraceLevel
        {
            get { return GetSetting("InternalTraceLevel", InternalTraceLevel.Off); }
            set { SaveSetting("InternalTraceLevel", value); }
        }
    }
}