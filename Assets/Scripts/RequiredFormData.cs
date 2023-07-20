using System;

namespace WoH.AbsoluteDivExample
{
    [Serializable]
    public class RequiredFormData
    {
        public FormSingleEntry[] data = { };
    }

    [Serializable]
    public class FormSingleEntry
    {
        public string formId = string.Empty;
        public string requiredFormValue = string.Empty;
    }
}
