namespace apbd_cw2_git_s33988;

public class Camera : Equipment
{
    public string Resolution { get; set; }
    public bool OpticalZoom { get; set; }
    public Camera(string name, string resolution, bool opticalZoom) : base(name)
    {
        Resolution = resolution;
        OpticalZoom = opticalZoom;
    }
}