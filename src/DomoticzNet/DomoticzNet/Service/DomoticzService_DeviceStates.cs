using DomoticzNet.Models;

using Newtonsoft.Json;

using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Web;

namespace DomoticzNet.Service
{
    public partial class DomoticzService
    {
        public Task SetLightSwitchState(int idx, bool state)
        {
            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = _QueryParamSwitchLight;
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query[_QuerySwitchCmd] = state ? Consts.On : Consts.Off;

            return InvokeApiCall<CommandResponse>(query);
        }

        /// <summary>
        /// Toggle a switch state between on/off
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public Task ToggleLightSwitchState(int idx)
        {
            //json.htm?type=command&param=switchlight&idx=99&switchcmd=Toggle

            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = _QueryParamSwitchLight;
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query[_QuerySwitchCmd] = _QuerySwitchCmdToggle;

            return InvokeApiCall<CommandResponse>(query);
        }

        /// <summary>
        /// Some lights have 100 dim levels (like zwave and others), other hardware (kaku/lightwaverf) have other ranges like 16/32
        /// Level should be the dim level(not percentage), like 0-16 or 0-100 depending on the hardware used
        /// When the light is off, it will be turned on
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="level">Level in device specific range</param>
        /// <returns></returns>
        public Task SetDimmLevel(int idx, int level)
        {
            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = _QueryParamSwitchLight;
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query[_QuerySwitchCmd] = "Set Level";
            query["level"] = level.ToString(CultureInfo.InvariantCulture);

            return InvokeApiCall<CommandResponse>(query);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="hue">Hue in range (0-360) degrees</param>
        /// <param name="brightness">Brightness in range (0-100)</param>
        /// <param name="isWhite"></param>
        /// <returns></returns>
        public Task SetLightColorHue(int idx, int hue, int brightness, bool isWhite)
        {
            //json.htm?type=command&param=setcolbrightnessvalue
            //&idx=99&hue=274&brightness=40&iswhite=false
            if (brightness < 0 || brightness > 100)
                throw new ArgumentOutOfRangeException(nameof(brightness), "Brightness must be in range (0-100)");
            if (hue < 0 || hue > 360)
                throw new ArgumentOutOfRangeException(nameof(hue), "Hue must be in range (0-360)");

            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = _QueryParamSetColor;
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query["hue"] = hue.ToString(CultureInfo.InvariantCulture);
            query[_QueryBrightness] = brightness.ToString(CultureInfo.InvariantCulture);
            query[_QueryIsWhite] = isWhite.ToString(CultureInfo.InvariantCulture);

            return InvokeApiCall<CommandResponse>(query);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="rgb">RGB as hexadecimal number</param>
        /// <param name="brightness">Brightness in range (0-100)</param>
        /// <param name="isWhite"></param>
        /// <returns></returns>
        public Task SetLightColorRgb(int idx, int rgb, int brightness, bool isWhite)
        {
            //json.htm?type=command&param=setcolbrightnessvalue&idx=99&hex=RRGGBB&brightness=100&iswhite=false
            if (brightness < 0 || brightness > 100)
                throw new ArgumentOutOfRangeException(nameof(brightness), "Brightness must be in range (0-100)");
            if (rgb < 0 || rgb > 0x00FFFFFF)
                throw new ArgumentOutOfRangeException(nameof(rgb), "rgb must be in form of 00RRGGBB");

            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = _QueryParamSetColor;
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query["hex"] = rgb.ToString("X8", CultureInfo.InvariantCulture);
            query[_QueryBrightness] = brightness.ToString(CultureInfo.InvariantCulture);
            query[_QueryIsWhite] = isWhite.ToString(CultureInfo.InvariantCulture);

            return InvokeApiCall<CommandResponse>(query);
        }

        /// <summary>
        /// Sets light color
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="color"></param>
        /// <param name="brightness">Brightness in range (0-100)</param>
        /// <returns></returns>
        public Task SetLightColor(int idx, ColorValue color, int brightness)
        {
            //json.htm?type=command&param=setcolbrightnessvalue
            //&idx=130&color={"m":3,"t":0,"r":0,"g":0,"b":50,"cw":0,"ww":0}
            //&brightness=100
            if (brightness < 0 || brightness > 100)
                throw new ArgumentOutOfRangeException(nameof(brightness), "Brightness must be in range (0-100)");

            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = _QueryParamSetColor;
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query[_QueryBrightness] = brightness.ToString(CultureInfo.InvariantCulture);
            query["color"] = JsonConvert.SerializeObject(color);

            return InvokeApiCall<CommandResponse>(query);
        }

        /// <summary>
        /// Set an RGB_CW_WW or CW_WW light to a certain color temperature
        /// </summary>
        /// <param name="kelvin">Range of kelvin parameter: 0..100, 0 is coldest, 100 is warmest</param>
        /// <returns></returns>
        public Task SetLightTemperature(int idx, byte kelvin)
        {
            //json.htm?type=command&param=setkelvinlevel&idx=99&kelvin=1
            if (kelvin > 100)
                throw new ArgumentOutOfRangeException(nameof(kelvin), "Must be in range (0-100)");

            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = "setkelvinlevel";
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query["kelvin"] = kelvin.ToString(CultureInfo.InvariantCulture);

            return InvokeApiCall<CommandResponse>(query);
        }

        public Task SetSceneState(int idx, bool state)
        {
            //json.htm?type=command&param=switchscene&idx=&switchcmd=

            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = "switchscene";
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query[_QuerySwitchCmd] = state ? Consts.On : Consts.Off;

            return InvokeApiCall<CommandResponse>(query);
        }

        public Task ToggleSceneState(int idx)
        {
            //json.htm?type=command&param=switchscene&idx=&switchcmd=

            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = "switchscene";
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query[_QuerySwitchCmd] = _QuerySwitchCmdToggle;

            return InvokeApiCall<CommandResponse>(query);
        }

        public Task SetThermostatSetPoint(int idx, float setPoint)
        {
            //json.htm?type=command&param=setsetpoint&idx=&setpoint=

            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = "setsetpoint";
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query["setpoint"] = setPoint.ToString(System.Globalization.CultureInfo.InvariantCulture);

            return InvokeApiCall<CommandResponse>(query);
        }

        /// <summary>
        /// Untested, not documented
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public Task SetThermostatMode(int idx, int mode)
        {
            //json.htm?type=command&param=switchmodal&idx=23&status=off&action=1

            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeCommand;
            query[_QueryParam] = "switchmodal";
            query[_QueryIdx] = idx.ToString(CultureInfo.InvariantCulture);
            query["status"] = mode.ToString(CultureInfo.InvariantCulture);
            query["action"] = "1";

            return InvokeApiCall<CommandResponse>(query);
        }
    }
}
