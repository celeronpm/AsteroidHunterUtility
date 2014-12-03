using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using _3DTools;

namespace MariusSoft.AsteroidHunter.Windows
{
    /// <summary>
    /// Interaction logic for _3Dpanel.xaml
    /// </summary>
    public partial class _3Dpanel : UserControl
    {
        Model3DGroup topography = new Model3DGroup();
        private Point3D[] points;

        public _3Dpanel()
        {
            InitializeComponent();

            //topographyButtonClick(null, null);
        }

        public void SetData(double[] data, int width, System.Drawing.Point topLeft, System.Drawing.Size Size)
        {
            ClearViewport();
            SetCamera(Size);
            topography.Children.Clear();

            if (points == null || points.Length != (Size.Width * Size.Height))
            {
                points = new Point3D[(Size.Width * Size.Height)];
            }

            Task.Factory.StartNew(() =>
            {
                int count = 0;
                for (int y = topLeft.Y; y < topLeft.Y + Size.Height; y++)
                {
                    for (int x = topLeft.X; x < topLeft.X + Size.Width; x++)
                    {
                        points[count] = new Point3D(x - topLeft.X, data[(y * width) + x], y - topLeft.Y);
                        count += 1;
                    }
                }
            })
                .ContinueWith(o =>
                {
                    for (int z = 0; z <= points.Length - (Size.Height * 2); z += Size.Height)
                    {
                        for (int x = 0; x < Size.Height - 1; x++)
                        {
                            topography.Children.Add(
                                CreateTriangleModel(
                                    points[x + z],
                                    points[x + z + Size.Width],
                                    points[x + z + 1])
                                );
                            topography.Children.Add(
                                CreateTriangleModel(
                                    points[x + z + 1],
                                    points[x + z + Size.Width],
                                    points[x + z + Size.Width + 1])
                                );
                        }
                    }

                    ModelVisual3D model = new ModelVisual3D { Content = topography };
                    mainViewport.Children.Add(model);
                },
                    TaskScheduler.FromCurrentSynchronizationContext());

        }

        private Point3D[] GetRandomTopographyPoints()
        {
            //create a 10x10 topography.
            Point3D[] points = new Point3D[100];
            Random r = new Random();
            double y;
            double denom = 1000;
            int count = 0;
            for (int z = 0; z < 10; z++)
            {
                for (int x = 0; x < 10; x++)
                {
                    System.Threading.Thread.Sleep(1);
                    y = Convert.ToDouble(r.Next(1, 999)) / denom;
                    points[count] = new Point3D(x, y, z);
                    count += 1;
                }
            }
            return points;
        }

        private void ClearViewport()
        {
            ModelVisual3D m;
            for (int i = mainViewport.Children.Count - 1; i >= 0; i--)
            {
                m = (ModelVisual3D)mainViewport.Children[i];
                if (m.Content is DirectionalLight == false)
                    mainViewport.Children.Remove(m);
            }
        }

        private Model3DGroup CreateTriangleModel(Point3D p0, Point3D p1, Point3D p2)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();
            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);
            Vector3D normal = CalculateNormal(p0, p1, p2);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            GeometryModel3D model = new GeometryModel3D(mesh, new DiffuseMaterial(new SolidColorBrush(Colors.DarkKhaki)));
            Model3DGroup group = new Model3DGroup();
            group.Children.Add(model);
            
            //ScreenSpaceLines3D wireframe = new ScreenSpaceLines3D();
            //wireframe.Points.Add(p0);
            //wireframe.Points.Add(p1);
            //wireframe.Points.Add(p2);
            //wireframe.Points.Add(p0);
            //wireframe.Color = Colors.LightGreen;
            //wireframe.Thickness = 1;
            //mainViewport.Children.Add(wireframe);
            return group;
        }

        private Vector3D CalculateNormal(Point3D p0, Point3D p1, Point3D p2)
        {
            Vector3D v0 = new Vector3D(
                p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z);
            Vector3D v1 = new Vector3D(
                p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
            return Vector3D.CrossProduct(v0, v1);
        }

        private void topographyButtonClick(object sender, RoutedEventArgs e)
        {
            ClearViewport();
            //SetCamera();
            Model3DGroup topography = new Model3DGroup();
            Point3D[] points = GetRandomTopographyPoints();
            for (int z = 0; z <= 80; z = z + 10)
            {
                for (int x = 0; x < 9; x++)
                {
                    topography.Children.Add(
                        CreateTriangleModel(
                                points[x + z],
                                points[x + z + 10],
                                points[x + z + 1])
                    );
                    topography.Children.Add(
                        CreateTriangleModel(
                                points[x + z + 1],
                                points[x + z + 10],
                                points[x + z + 11])
                    );
                }
            }
            ModelVisual3D model = new ModelVisual3D();
            model.Content = topography;
            mainViewport.Children.Add(model);
        }

        private void SetCamera(System.Drawing.Size size)
        {
            PerspectiveCamera camera = (PerspectiveCamera)mainViewport.Camera;
            camera.FarPlaneDistance = 500;
            //camera.FieldOfView = 80;
            Point3D position = new Point3D(
                Convert.ToDouble(size.Width/2),
                Convert.ToDouble(15),
                Convert.ToDouble(-20)
            );
            Vector3D lookDirection = new Vector3D(
                Convert.ToDouble(0),
                Convert.ToDouble(-.5),
                Convert.ToDouble(1)
            );
            camera.Position = position;
            camera.LookDirection = lookDirection;
        }

    }
}
