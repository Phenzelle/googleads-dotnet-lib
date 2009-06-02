// Copyright 2009, Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using com.google.api.adwords.lib;
using com.google.api.adwords.v13;

using System;
using System.Collections;
using com.google.api.adwords.lib.util;
using System.Collections.Generic;

namespace com.google.api.adwords.samples.v13 {
  /// <summary>
  /// This demo displays API method usage for this month for all methods provided
  /// by the AdWords API. Note that this data is not in real time and is refreshed
  /// every few hours.
  /// </summary>
  class MethodQuotaUsageDemo : SampleBase {
    /// <summary>
    /// Returns a description about the sample code.
    /// </summary>
    public override string Description {
      get {
        return "Displays API method usage for this month for all methods provided" +
            " by the AdWords API.";
      }
    }

    /// <summary>
    /// Run the sample code.
    /// </summary>
    /// <param name="user">The AdWords user object running the sample.
    /// </param>
    public override void Run(AdWordsUser user) {
      user.ResetUnits();
      List<MethodQuotaUsage> methodQuotaUsage = UnitsUtilities.GetMethodQuotaUsage(user,
          DateTime.Now.AddMonths(-1), DateTime.Now);

      foreach (MethodQuotaUsage usage in methodQuotaUsage) {
        Console.WriteLine("{0,-50} - {1}", usage.serviceName + "." + usage.methodName,
            usage.units);
      }
      Console.WriteLine("\nTotal Quota unit cost for this run: {0}.\n", user.GetUnits());
    }
  }
}
