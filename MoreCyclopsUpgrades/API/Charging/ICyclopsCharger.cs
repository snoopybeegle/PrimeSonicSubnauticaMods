﻿namespace MoreCyclopsUpgrades.API.Charging
{
    using UnityEngine;

    /// <summary>
    /// Defines all the behaviors for a cyclops charger that handles a particular type of energy recharging.<para/>
    /// Recharging may be part of an update module or it might be a new buidable.<para/>
    /// Whatever the case, it is up to you to ensure you have all your references set and ready.<para/>
    /// DO NOT recharge the Cyclops PowerRelay yourself from this class!!! The MoreCyclopsUpgrades PowerManager will handle that.<para/>
    /// </summary>
    public interface ICyclopsCharger
    {
        /// <summary>
        /// Produces power for the Cyclops during the RechargeCyclops update cycle.<para/>
        /// This method should return <c>0f</c> if there is no power avaiable from this charging handler.<para/>
        /// You may limit the amount of power produced to only what the cyclops needs or you may return more.<para/>
        /// DO NOT recharge the Cyclops PowerRelay yourself from this method!!! The MoreCyclopsUpgrades PowerManager will handle that.<para/>
        /// </summary>
        /// <param name="requestedPower">The amount of power being requested by the cyclops; This is the current Power Deficit of the cyclops.</param>
        /// <returns>The amount of power produced by this cyclops charger.</returns>
        float ProducePower(float requestedPower);

        /// <summary>
        /// Gets a value indicating if this type of cyclops energy source is renewable.<para/>
        /// Use <c>true</c> for rechargable batteries and energy drawn from the environment.<para/>
        /// Use <c>false</c> for depletable sources like nuclear reactor rods.<para/>
        /// This is not expected to change over time.
        /// </summary>
        bool IsRenewable { get; }

        /// <summary>
        /// Gets the name that identifies this <see cref="ICyclopsCharger"/> among all others in the Cyclops sub.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Determines whether this charger should display any power indicator info.<para/>
        /// This method is called roughly every 3 seconds when the Cyclops HUD info is updated.<para/>
        /// </summary>
        /// <returns>
        ///   <c>true</c> if a power indicator should be shown; otherwise, <c>false</c>.
        /// </returns>
        bool HasPowerIndicatorInfo();

        /// <summary>
        /// Gets the sprite to use for the power indicator. This will only be called when <see cref="HasPowerIndicatorInfo"/> returns <c>true</c>.
        /// </summary>
        /// <returns>A new <see cref="Atlas.Sprite"/> to be used in the Cyclops Helm and Holographic HUDs.</returns>
        Atlas.Sprite GetIndicatorSprite();

        /// <summary>
        /// Gets the text to use under the power indicator icon. This will only be called when <see cref="HasPowerIndicatorInfo"/> returns <c>true</c>.
        /// </summary>
        /// <returns>A <see cref="string"/>, ready to use for in-game text. Should be limited to numeric values if possible.</returns>
        string GetIndicatorText();

        /// <summary>
        /// Gets the color of the text used under the power indicator icon. This will only be called when <see cref="HasPowerIndicatorInfo"/> returns <c>true</c>.
        /// </summary>
        /// <returns>A Unity <see cref="Color"/> value for the text. When in doubt, just set this to white.</returns>
        Color GetIndicatorTextColor();

        /// <summary>
        /// If the charger has its own store of energy, return the total available reserve power.
        /// </summary>
        /// <returns>The total power the charger is capable of providing over time; Return 0f if there are no power reserves.</returns>
        float TotalReservePower();
    }
}