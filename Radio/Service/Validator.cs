using System;
using System.Drawing;
using System.Windows.Forms;

namespace Radio.Service
{
    public class Validator
    {
        private readonly Control control = null;
        private readonly string text = null;
        private bool isValidate = false;

        public Validator(Control control)
        {
            this.control = control;
            text = control.Text;
            isValidate = false;
        }

        public Validator SetValidateRules(params string[] values)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (values.IsNullOrEmpty())
                {
                    isValidate = true;
                }
                else
                {
                    foreach (string value in values)
                    {
                        if (control.Text.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            isValidate = true;
                            break;
                        }
                    }
                }
            }
            return this;
        }

        public bool Validate()
        {
            control.BackColor = isValidate ? Color.Green : Color.Red;
            return isValidate;
        }
    }
}
