using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished; // 動画が終了したらOnVideoFinishedを呼ぶ
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("SkyBossScene2"); // 動画が終了したら次のシーンへ
    }
}
