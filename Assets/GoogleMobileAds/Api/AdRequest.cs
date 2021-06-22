/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

// Copyright (C) 2015 Google, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace GoogleMobileAds.Api
{
    public class AdRequest
    {
        public const string Version = "3.0.0";
        public const string TestDeviceSimulator = "SIMULATOR";

        public class Builder
        {
            private List<string> testDevices;
            private HashSet<string> keywords;
            private DateTime? birthday;
            private Gender? gender;
            private bool? tagForChildDirectedTreatment;
            private Dictionary<string, string> extras;

            public Builder()
            {
                this.testDevices = new List<string>();
                this.keywords = new HashSet<string>();
                this.birthday = null;
                this.gender = null;
                this.tagForChildDirectedTreatment = null;
                this.extras = new Dictionary<string, string>();
            }

            public Builder AddKeyword(string keyword)
            {
                this.keywords.Add(keyword);
                return this;
            }

            public Builder AddTestDevice(string deviceId)
            {
                this.testDevices.Add(deviceId);
                return this;
            }

            public AdRequest Build()
            {
                return new AdRequest(this);
            }

            public Builder SetBirthday(DateTime birthday)
            {
                this.birthday = birthday;
                return this;
            }

            public Builder SetGender(Gender gender)
            {
                this.gender = gender;
                return this;
            }

            public Builder TagForChildDirectedTreatment(bool tagForChildDirectedTreatment)
            {
                this.tagForChildDirectedTreatment = tagForChildDirectedTreatment;
                return this;
            }

            public Builder AddExtra(string key, string value)
            {
                this.extras.Add(key, value);
                return this;
            }

            internal List<string> TestDevices
            {
                get
                {
                    return testDevices;
                }
            }

            internal HashSet<string> Keywords
            {
                get
                {
                    return keywords;
                }
            }

            internal DateTime? Birthday
            {
                get
                {
                    return birthday;
                }
            }

            internal Gender? Gender
            {
                get
                {
                    return gender;
                }
            }

            internal bool? ChildDirectedTreatmentTag
            {
                get
                {
                    return tagForChildDirectedTreatment;
                }
            }

            internal Dictionary<string, string> Extras
            {
                get
                {
                    return extras;
                }
            }
        }

        private List<string> testDevices;
        private HashSet<string> keywords;
        private DateTime? birthday;
        private Gender? gender;
        private bool? tagForChildDirectedTreatment;
        private Dictionary<string, string> extras;

        private AdRequest(Builder builder)
        {
            testDevices = builder.TestDevices;
            keywords = builder.Keywords;
            birthday = builder.Birthday;
            gender = builder.Gender;
            tagForChildDirectedTreatment = builder.ChildDirectedTreatmentTag;
            extras = builder.Extras;
        }

        public List<string> TestDevices
        {
            get
            {
                return testDevices;
            }
        }

        public HashSet<string> Keywords
        {
            get
            {
                return keywords;
            }
        }

        public DateTime? Birthday
        {
            get
            {
                return birthday;
            }
        }

        public Gender? Gender
        {
            get
            {
              return gender;
            }
        }

        public bool? TagForChildDirectedTreatment
        {
            get
            {
                return tagForChildDirectedTreatment;
            }
        }

        public Dictionary<string, string> Extras
        {
            get
            {
                return extras;
            }
        }
    }
}
