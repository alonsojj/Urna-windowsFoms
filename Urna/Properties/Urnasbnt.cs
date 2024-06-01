using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Urna.Properties
{
    public partial class Urnasbnt : Component
    {
        public Urnasbnt()
        {
            InitializeComponent();
        }

        public Urnasbnt(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
