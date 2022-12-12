using UnityEngine;

namespace Utillites.Image {

    public static class ImageUtils {
        public static Sprite SpriteFromTexture2D(Texture2D texture) {
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }
}
