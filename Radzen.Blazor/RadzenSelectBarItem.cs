﻿using Microsoft.AspNetCore.Components;

namespace Radzen.Blazor
{
    public class RadzenSelectBarItem : RadzenComponent
    {
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public object Value { get; set; }

        IRadzenSelectBar _selectBar;

        [CascadingParameter]
        public IRadzenSelectBar SelectBar
        {
            get
            {
                return _selectBar;
            }
            set
            {
                if (_selectBar != value)
                {
                    _selectBar = value;
                    _selectBar.AddItem(this);
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            SelectBar?.RemoveItem(this);
        }

        internal void SetText(string value)
        {
            Text = value;
        }

        internal void SetValue(object value)
        {
            Value = value;
        }
    }
}