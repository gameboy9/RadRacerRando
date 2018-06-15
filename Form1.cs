using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcitebikeRando
{
    public partial class Form1 : Form
    {
        bool loading = true;
        byte[] romData;
        byte[] romData2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSeed.Text = (DateTime.Now.Ticks % 2147483647).ToString();

            try
            {
                using (TextReader reader = File.OpenText("lasteb.txt"))
                {
                    txtFlags.Text = reader.ReadLine();
                    txtFileName.Text = reader.ReadLine();

                    determineChecks(null, null);

                    runChecksum();
                    loading = false;
                }
            }
            catch
            {
                // ignore error
                loading = false;
                cboTimerDifficulty.SelectedIndex = 2;
                cboTrackLength.SelectedIndex = 2;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = File.CreateText("lasteb.txt"))
            {
                writer.WriteLine(txtFlags.Text);
                writer.WriteLine(txtFileName.Text);
            }
        }

        private void runChecksum()
        {
            try
            {
                using (var md5 = SHA1.Create())
                {
                    using (var stream = File.OpenRead(txtFileName.Text))
                    {
                        lblSHAChecksum.Text = BitConverter.ToString(md5.ComputeHash(stream)).ToLower().Replace("-", "");
                    }
                }
            }
            catch
            {
                lblSHAChecksum.Text = "????????????????????????????????????????";
            }
        }

        private bool loadRom(bool extra = false)
        {
            try
            {
                romData = File.ReadAllBytes(txtFileName.Text);
                if (extra)
                    romData2 = File.ReadAllBytes(txtCompare.Text);
            }
            catch
            {
                MessageBox.Show("Empty file name(s) or unable to open files.  Please verify the files exist.");
                return false;
            }
            return true;
        }

        private void saveRom()
        {
            string options = "";
            string finalFile = Path.Combine(Path.GetDirectoryName(txtFileName.Text), "R3_" + txtSeed.Text + "_" + txtFlags.Text + ".nes");
            File.WriteAllBytes(finalFile, romData);
            lblStatus.Text = "ROM hacking complete!  (" + finalFile + ")";
            txtCompare.Text = finalFile;
        }

        private void btnNewSeed_Click(object sender, EventArgs e)
        {
            txtSeed.Text = (DateTime.Now.Ticks % 2147483647).ToString();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
                runChecksum();
            }
        }

        private void determineFlags(object sender, EventArgs e)
        {
            if (loading)
                return;

            string flags = "";
            //int number = (chkObstacles.Checked ? 1 : 0) + (chkColors.Checked ? 2 : 0) + (chkBikeSpeed.Checked ? 4 : 0) + (chkVSTracks.Checked ? 8 : 0) + (chkVSOpponents.Checked ? 16 : 0);
            //flags += convertIntToChar(number);

            flags += cboTimerDifficulty.SelectedIndex.ToString();
            flags += cboTrackLength.SelectedIndex.ToString();

            txtFlags.Text = flags;
        }

        private void determineChecks(object sender, EventArgs e)
        {
            if (txtFlags.Text.Length != 2) return;
            loading = true;
            string flags = txtFlags.Text;
            //int number = convertChartoInt(Convert.ToChar(flags.Substring(0, 1)));
            //chkObstacles.Checked = (number % 2 == 1);
            //chkColors.Checked = (number % 4 >= 2);
            //chkBikeSpeed.Checked = (number % 8 >= 4);
            //chkVSTracks.Checked = (number % 16 >= 8);
            //chkVSOpponents.Checked = (number % 32 >= 16);

            string laps = flags.Substring(0, 1);
            //if (laps == "R")
            //    cboTimerDifficulty.SelectedIndex = 9;
            //else if (laps == "L")
            //    cboTimerDifficulty.SelectedIndex = 10;
            //else if (laps == "H")
            //    cboTimerDifficulty.SelectedIndex = 11;
            //else
            cboTimerDifficulty.SelectedIndex = Convert.ToInt32(laps);

            //laps = flags.Substring(2, 1);
            //if (laps == "R")
            //    cboExcitebikeLaps.SelectedIndex = 9;
            //else if (laps == "L")
            //    cboExcitebikeLaps.SelectedIndex = 10;
            //else if (laps == "H")
            //    cboExcitebikeLaps.SelectedIndex = 11;
            //else
            //    cboExcitebikeLaps.SelectedIndex = Convert.ToInt32(laps) - 1;

            laps = flags.Substring(1, 1);
            cboTrackLength.SelectedIndex = Convert.ToInt32(laps);

            loading = false;
        }

        private string convertIntToChar(int number)
        {
            if (number >= 0 && number <= 9)
                return number.ToString();
            if (number >= 10 && number <= 35)
                return Convert.ToChar(55 + number).ToString();
            if (number >= 36 && number <= 61)
                return Convert.ToChar(61 + number).ToString();
            if (number == 62) return "!";
            if (number == 63) return "@";
            return "";
        }

        private int convertChartoInt(char character)
        {
            if (character >= Convert.ToChar("0") && character <= Convert.ToChar("9"))
                return character - 48;
            if (character >= Convert.ToChar("A") && character <= Convert.ToChar("Z"))
                return character - 55;
            if (character >= Convert.ToChar("a") && character <= Convert.ToChar("z"))
                return character - 61;
            if (character == Convert.ToChar("!")) return 62;
            if (character == Convert.ToChar("@")) return 63;
            return 0;
        }

        private void cmdRandomize_Click(object sender, EventArgs e)
        {
            //try
            //{
                loadRom();
                Random r1 = new Random(Convert.ToInt32(txtSeed.Text));
                randomizeTracks(r1);
                saveRom();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error:  " + ex.Message);
            //}
        }

        private void randomizeTracks(Random r1)
        {
            // 27, 23, 23, 23, 27, 25, 28, 26
            List<int[]>[] mapPoints = new List<int[]>[8];
            for (int lnI = 0; lnI < 8; lnI++)
            {
                int romAddress = 0x1f + (0x600 * lnI);
                mapPoints[lnI] = new List<int[]>();
                while (romData[romAddress] != 0xff)
                {
                    if (romData[romAddress] == 0xf5)
                    {
                        mapPoints[lnI].Add(new int[] { romData[romAddress + 1], romData[romAddress + 2] });
                        romAddress += 3;
                    }
                    else
                    {
                        romAddress++;
                    }
                }
            }

            for (int lnI = 0; lnI < 8; lnI++)
            {
                int romAddress = 0x1f + (0x600 * lnI);
                romData[romAddress + 0] = 0x00;
                romData[romAddress + 1] = 0x00;
                romData[romAddress + 2] = 0x00;
                int marker = 3;
                int trackLength = 400 + (100 * cboTrackLength.SelectedIndex) + (20 * lnI) + (r1.Next() % 50);
                int checkPoint1 = (cboTimerDifficulty.SelectedIndex == 0 ? 70 : cboTimerDifficulty.SelectedIndex == 1 ? 80 : cboTimerDifficulty.SelectedIndex == 2 ? 90 : cboTimerDifficulty.SelectedIndex == 3 ? 100 : 110) + r1.Next() % 10;
                int checkPoint2 = checkPoint1 + ((trackLength - checkPoint1) / 3) - 25 + (r1.Next() % 50);
                int checkPoint3 = checkPoint2 + ((trackLength - checkPoint2) / 2) - 25 + (r1.Next() % 50);
                //int checkPoint2 = checkPoint1 + 60 + (20 * cboTrackLength.SelectedIndex) + (r1.Next() % (60 + (20 * cboTrackLength.SelectedIndex)));
                //int checkPoint3 = checkPoint2 + 60 + (20 * cboTrackLength.SelectedIndex) + (r1.Next() % (60 + (20 * cboTrackLength.SelectedIndex)));
                int[] checkPoints = { checkPoint1, checkPoint2, checkPoint3, trackLength };
                int cpMarked = 0;
                int curveInProgress = 0x90;
                byte obstacle = 0x77;
                int obstacleFrequency = 4;
                int obstacleMarker = 0;
                int mapPointsNumber = mapPoints[lnI].Count + 1;
                int mapPointMarker = trackLength / mapPointsNumber;
                int mapPointMarker2 = 0;

                while (marker < trackLength)
                {
                    if (r1.Next() % (14 - lnI) == 0)
                    {
                        curve(romAddress, ref marker, r1, ref curveInProgress, lnI);
                    }

                    if (r1.Next() % 18 == 0)
                    {
                        hill(romAddress, ref marker, r1, lnI);
                    }

                    if (r1.Next() % 20 == 0)
                    {
                        car(romAddress, ref marker, r1, lnI);
                    }

                    if (r1.Next() % 12 == 0)
                    {
                        obstacleFrequency = r1.Next() % (5 + lnI);
                        if (obstacleFrequency > 4) obstacleFrequency = 4;
                        int obstacle1 = r1.Next() % 3;
                        int obstacle2 = r1.Next() % 3;
                        obstacle = (byte)((obstacle1 == 0 ? 0 : obstacle1 == 1 ? 0x60 : 0x70) + (obstacle2 == 0 ? 0 : obstacle2 == 1 ? 6 : 7));
                    }

                    if (obstacleFrequency == 4 || (obstacleFrequency == 3 && obstacleMarker != 0) || (obstacleFrequency == 2 && obstacleMarker != 0 && obstacleMarker != 2) || (obstacleFrequency == 1 && obstacleMarker == 2))
                        romData[romAddress + marker] = obstacle;
                    else
                        romData[romAddress + marker] = 0;
                    obstacleMarker++;
                    if (obstacleMarker == 4) obstacleMarker = 0;
                    marker++;

                    cpMarked = checkForTimeExtension(romAddress, ref marker, checkPoints, cpMarked, trackLength);

                    if (marker > mapPointMarker && mapPointMarker2 < (mapPointsNumber - 1))
                    {
                        romData[romAddress + marker] = 0xf5;
                        romData[romAddress + marker + 1] = (byte)mapPoints[lnI][mapPointMarker2][0];
                        romData[romAddress + marker + 2] = (byte)mapPoints[lnI][mapPointMarker2][1];
                        mapPointMarker2++;
                        mapPointMarker = trackLength * (mapPointMarker2 + 1) / mapPointsNumber;
                        marker += 3; 
                    }
                }
                romData[romAddress + marker + 0] = 0x33;
                romData[romAddress + marker + 1] = 0x33;
                romData[romAddress + marker + 2] = 0x33;
                romData[romAddress + marker + 3] = 0xff;
            }
        }

        private void hill(int romAddress, ref int marker, Random r1, int currentTrack)
        {
            int hillUse = r1.Next() % 3;
            if (hillUse == 0)
            {
                romData[romAddress + marker] = 0xf6;
            } else if (hillUse == 1)
            {
                int hillHeight = inverted_power_curve(0, 15, 1 + (.2 * currentTrack), r1);
                romData[romAddress + marker] = (byte)(hillHeight + 0xa0);
            } else
            {
                int hillHeight = inverted_power_curve(0, 15, 1 + (.2 * currentTrack), r1);
                romData[romAddress + marker] = (byte)(hillHeight + 0xb0);
            }
            marker++;
        }

        private void car(int romAddress, ref int marker, Random r1, int currentTrack)
        {
            int laneUse = r1.Next() % 3;
            int carUse = r1.Next() % 3;
            if (carUse == 0) // car frequency
            {
                if (currentTrack >= 5)
                    romData[romAddress + marker] = (byte)(0xc0 + (16 * laneUse) + 11 + (r1.Next() % 3));
                else
                    romData[romAddress + marker] = (byte)(0xc0 + (16 * laneUse) + 11 + (r1.Next() % 5));
            } else if (carUse == 1) // car crash difference
            {
                if (currentTrack >= 6)
                    romData[romAddress + marker] = (byte)(0xc0 + (16 * laneUse) + 6 + (r1.Next() % 4));
                else if (currentTrack >= 4)
                    romData[romAddress + marker] = (byte)(0xc0 + (16 * laneUse) + 8 + (r1.Next() % 2));
            }
            else // Car speed boost
            {
                if (currentTrack >= 5)
                    romData[romAddress + marker] = (byte)(0xc0 + (16 * laneUse) + 1 + (r1.Next() % 4));
                else if (currentTrack >= 3)
                    romData[romAddress + marker] = (byte)(0xc0 + (16 * laneUse) + 3 + (r1.Next() % 2));
            }
        }

        private void curve(int romAddress, ref int marker, Random r1, ref int curveInProgress, int currentTrack)
        {
            bool curveContinue = false;
            if (curveInProgress == 0x90)
                curveContinue = true;
            else if (currentTrack >= 6)
                curveContinue = (r1.Next() % 4 != 0);
            else if (currentTrack >= 4)
                curveContinue = (r1.Next() % 2 == 0);
            else
                curveContinue = (r1.Next() % 3 == 0);
            if (curveContinue)
            {
                int warning = 5 - (currentTrack / 2) - (curveInProgress != 0x90 ? 1 : 0);
                bool leftCurve = false;
                if (curveInProgress < 0x90 && r1.Next() % 4 != 0)
                    leftCurve = true;
                else if (curveInProgress > 0x90 && r1.Next() % 4 == 0)
                    leftCurve = true;
                else if (r1.Next() % 2 == 1)
                    leftCurve = true;

                if (leftCurve)
                {
                    int curveStrength = inverted_power_curve(1, 16, 2.0, r1);
                    if (curveContinue && (0x90 - curveStrength) <= curveInProgress)
                        for (int lnJ = 0; lnJ < warning; lnJ++)
                        {
                            romData[romAddress + marker] = 0x02;
                            marker++;
                        }
                    romData[romAddress + marker] = (byte)(0x90 - curveStrength);
                    curveInProgress = 0x90 - curveStrength;
                }
                else
                {
                    int curveStrength = inverted_power_curve(1, 15, 2.0, r1);
                    if (curveContinue && (0x90 + curveStrength) >= curveInProgress)
                        for (int lnJ = 0; lnJ < warning; lnJ++)
                        {
                            romData[romAddress + marker] = 0x10;
                            marker++;
                        }
                    romData[romAddress + marker] = (byte)(0x90 + curveStrength);
                    curveInProgress = 0x90 + curveStrength;
                }
            } else
                romData[romAddress + marker] = 0x90;
            marker++;
        }

        private int checkForTimeExtension(int romAddress, ref int marker, int[] checkPoints, int cpMarked, int trackLength)
        {
            if (marker > checkPoints[cpMarked] && cpMarked < 3)
            {
                romData[romAddress + marker] = 0x33;
                romData[romAddress + marker + 1] = 0xf4;
                double timeDividend = (cboTimerDifficulty.SelectedIndex == 0 ? 2.2 : cboTimerDifficulty.SelectedIndex == 1 ? 2.6 : cboTimerDifficulty.SelectedIndex == 2 ? 3.0 : cboTimerDifficulty.SelectedIndex == 3 ? 3.5 : 4.0);
                double timeToAdd = ((checkPoints[cpMarked + 1] - checkPoints[cpMarked]) / timeDividend);
                romData[romAddress + marker + 2] = (byte)(Math.Ceiling(timeToAdd));
                marker += 3;
                return cpMarked + 1;
            } else
            {
                return cpMarked;
            }
        }

        private int ScaleValue(int value, double scale, double adjustment, Random r1)
        {
            var exponent = (double)r1.Next() / int.MaxValue * 2.0 - 1.0;
            var adjustedScale = 1.0 + adjustment * (scale - 1.0);

            return (int)Math.Round(Math.Pow(adjustedScale, exponent) * value, MidpointRounding.AwayFromZero);
        }

        private int inverted_power_curve(int min, int max, double powToUse, Random r1)
        {
            int range = max - min;
            double p_range = Math.Pow(range, 1 / powToUse);
            double section = (double)r1.Next() / int.MaxValue;
            int points = (int)Math.Round(max - Math.Pow(section * p_range, powToUse));
            return points;
        }
    }
}
