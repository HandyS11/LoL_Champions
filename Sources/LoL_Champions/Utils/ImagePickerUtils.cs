using LoL_Champions.Converters;

namespace LoL_Champions.Utils
{
    public class ImagePickerUtils
    {
        public static async Task<string> ChooseImageB64()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    var source = ImageSource.FromStream(() => stream);
                    return new Base64ToImageConverter().ConvertBack(source, null, null, null) as string;
                }
            }
            return null;
        }
    }
}
