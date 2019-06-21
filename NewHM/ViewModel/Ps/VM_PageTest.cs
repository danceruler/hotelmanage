using MyControl;
using NewHM.View;
using NewHM.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace NewHM.ViewModel.Ps
{
    public class VM_PageTest : BaseViewModel
    {
        public VM_PageTest()
        {
            LevelMenuButtonGroup levelMenuButtonGroup = new LevelMenuButtonGroup();
            List<LevelMenuButtonMainItem> items = new List<LevelMenuButtonMainItem>();
            items.Add(new LevelMenuButtonMainItem()
            {
                name = "主目录1",
                placementMode = PlacementMode.Bottom,
                SonItems = new List<LevelMenuButtonMainItem>()
                    {
                        new LevelMenuButtonMainItem()
                        {
                            name = "小标题1",
                            placementMode = PlacementMode.Right,
                            SonItems = new List<LevelMenuButtonMainItem>()
                            {
                                new LevelMenuButtonMainItem()
                                {
                                    name = "小小标题1",
                                    placementMode = PlacementMode.Right,
                                    OnClick = (s,e)=>{
                                        MessageBox.Show("小小标题1");
                                    },
                                    SonItems = new List<LevelMenuButtonMainItem>()

                                },new LevelMenuButtonMainItem()
                                {
                                    name = "小小标题2",
                                    placementMode = PlacementMode.Right,
                                    SonItems = new List<LevelMenuButtonMainItem>()
                                }
                            }
                        },new LevelMenuButtonMainItem()
                        {
                            name = "小标题2",
                            placementMode = PlacementMode.Right,
                            SonItems = new List<LevelMenuButtonMainItem>()
                            {
                                new LevelMenuButtonMainItem()
                                {
                                    name = "小小标题3",
                                    placementMode = PlacementMode.Right,
                                    SonItems = new List<LevelMenuButtonMainItem>()
                                },new LevelMenuButtonMainItem()
                                {
                                    name = "小小标题4",
                                    placementMode = PlacementMode.Right,
                                    SonItems = new List<LevelMenuButtonMainItem>()
                                }
                            }
                        },new LevelMenuButtonMainItem()
                        {
                            name = "小标题3",
                            placementMode = PlacementMode.Right,
                            SonItems = new List<LevelMenuButtonMainItem>()
                            {
                                new LevelMenuButtonMainItem()
                                {
                                    name = "小小标题5",
                                    placementMode = PlacementMode.Right,
                                    SonItems = new List<LevelMenuButtonMainItem>()
                                },new LevelMenuButtonMainItem()
                                {
                                    name = "小小标题6",
                                    placementMode = PlacementMode.Right,
                                    SonItems = new List<LevelMenuButtonMainItem>()
                                }
                            }
                        }
                    }
            });
            items.Add(new LevelMenuButtonMainItem()
            {
                name = "主目录2",
                placementMode = PlacementMode.Bottom,
                SonItems = new List<LevelMenuButtonMainItem>()
                    {
                        new LevelMenuButtonMainItem()
                        {
                            name = "小标题4",
                            placementMode = PlacementMode.Right,
                            SonItems = new List<LevelMenuButtonMainItem>()
                            {
                                 new LevelMenuButtonMainItem()
                                {
                                    name = "小小标题7",
                                    placementMode = PlacementMode.Right,
                                    SonItems = new List<LevelMenuButtonMainItem>()
                                },new LevelMenuButtonMainItem()
                                {
                                    name = "小小标题8",
                                    placementMode = PlacementMode.Right,
                                    SonItems = new List<LevelMenuButtonMainItem>()
                                }
                            }
                        },new LevelMenuButtonMainItem()
                        {
                            name = "小标题5",
                            placementMode = PlacementMode.Right,
                            SonItems = new List<LevelMenuButtonMainItem>()
                            {
                                 new LevelMenuButtonMainItem()
                                {
                                    name = "小小标题9",
                                    placementMode = PlacementMode.Right,
                                    SonItems = new List<LevelMenuButtonMainItem>()
                                },new LevelMenuButtonMainItem()
                                {
                                    name = "小小标题10",
                                    placementMode = PlacementMode.Right,
                                    SonItems = new List<LevelMenuButtonMainItem>()
                                }
                            }
                        },new LevelMenuButtonMainItem()
                        {
                            name = "小标题6",
                            placementMode = PlacementMode.Right,
                            SonItems = new List<LevelMenuButtonMainItem>()
                        }
                    }
            }
            );
            levelMenuButtonGroup.MainButtonGroup = items;
            (this.UIElement as PageTest).MenuPanel.Children.Add(levelMenuButtonGroup);
        }
    }
}
