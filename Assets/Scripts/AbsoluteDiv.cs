using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace WoH.AbsoluteDivExample
{
    public class AbsoluteDiv : MonoBehaviour
    {
        private const string IdArg = "id";
        private const string WidthArg = "width";
        private const string HeightArg = "height";
        private const string PosXArg = "posX";
        private const string PosYArg = "posY";
        private const string OnClickArg = "href";
        private const string BackgroundColorTagArg = "backColor";
        private const string FontSizeArg = "fontSize";
        private const string FontStyleTagArg = "fontStyle";
        private const string ColorTagArg = "color";
        private const string TextAlignmentArg = "alignment";
        private const string FormDataArg = "formData";
        private const string IsFormArg = "isForm";

        [SerializeField]
        private RectTransform _rectTransform;
        [SerializeField]
        private TMP_Text _text;
        [SerializeField]
        private TMP_InputField _inputField;
        [SerializeField]
        private TMP_FontAsset _fontRegular;
        [SerializeField]
        private TMP_FontAsset _fontBold;
        [SerializeField]
        private TMP_FontAsset _fontMono;
        [SerializeField]
        private Image _backgroundImage;
        [SerializeField]
        private string _hrefLink;
        [SerializeField]
        private RequiredFormData _formData;

        public string BuildTag()
        {
            var sb = new StringBuilder();
            sb.Append("<absoluteDiv ");
            sb.Append($"{WidthArg}=\"{_rectTransform.sizeDelta.x}\" {HeightArg}=\"{_rectTransform.sizeDelta.y}\" ");
            sb.Append($"{PosXArg}=\"{_rectTransform.anchoredPosition.x}\" {PosYArg}=\"{_rectTransform.anchoredPosition.y}\" ");
            sb.Append($"{BackgroundColorTagArg}=\"{ColorUtility.ToHtmlStringRGBA(_backgroundImage.color)}\" ");
            sb.Append($"{FontSizeArg}=\"{_text.fontSize}\" ");
            if (_text.font == _fontBold)
            {
                sb.Append($"{FontStyleTagArg}=\"bold\" ");
            }
            else if (_text.font == _fontMono)
            {
                sb.Append($"{FontStyleTagArg}=\"mono\" ");
            }
            sb.Append($"{ColorTagArg}=\"{ColorUtility.ToHtmlStringRGBA(_text.color)}\" ");
            sb.Append($"{TextAlignmentArg}=\"{_text.horizontalAlignment}\" ");
            if (_formData != null && _formData.data.Length > 0)
            {
                sb.Append($"{FormDataArg}=\"{UnityWebRequest.EscapeURL(JsonUtility.ToJson(_formData))}\" ");
            }
            sb.Append($"{IsFormArg}={_inputField.gameObject.activeInHierarchy} ");
            sb.Append($"{IdArg}=\"{gameObject.name}\" ");

            if (!string.IsNullOrEmpty(_hrefLink))
            {
                sb.Append($"{OnClickArg}=\"{_hrefLink}\"");
            }

            if (_inputField.gameObject.activeInHierarchy)
            {
                sb.Append($">{_inputField.text}</absoluteDiv>");
            }
            else
            {
                sb.Append($">{_text.text}</absoluteDiv>");
            }
            return sb.ToString();
        }
    }
}
