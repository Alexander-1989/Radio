using System;
using System.Drawing;
using System.Windows.Forms;

namespace Radio.Service
{
    public class Validator
    {
        private readonly Control _control = null;
        private readonly string _text = null;
        private bool _isValidate = false;

        public Validator(Control control)
        {
            _control = control;
            _text = control.Text;
            _isValidate = false;
        }

        public Validator SetValidateRules(params string[] values)
        {
            if (!string.IsNullOrEmpty(_text))
            {
                if (values.IsNullOrEmpty())
                {
                    _isValidate = true;
                }
                else
                {
                    foreach (string value in values)
                    {
                        if (_control.Text.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            _isValidate = true;
                            break;
                        }
                    }
                }
            }
            return this;
        }

        public bool Validate()
        {
            _control.BackColor = _isValidate ? Color.Green : Color.Red;
            return _isValidate;
        }
    }
}
