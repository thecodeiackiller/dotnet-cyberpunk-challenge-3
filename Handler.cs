using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_cyberpunk_challenge_3.malware;
using dotnet_cyberpunk_challenge_3.malware.lib._lib;

namespace dotnet_cyberpunk_challenge_3
{
    public static class Handler
    {
        public static async Task StartTheChallenges(){
            /*
                OBJECTIVE: We've learned that Militech has just stolen a number of files from
                Arasaka and while that's great we also want our hands on those files. We can't
                break into Militech YET. 
                
                First we need you to adapt the Kuang malware we used on Arasaka to also be able
                to attack Militech without losing any capability to attack Arasaka either. The
                trick is to make the Kuang malware generic enough that can we spin up an attack
                process for both of them at a moment's notice.

                Couple concepts you'll need to remember from your recent adventures:
                - Async/await and how the `Task` datatype works
                - Generics
                - Abstraction (hiding all the super complicated stuff, like we're doing in the path
                 `lib/_lib/`)
                - Remember we're talking with an actual API and getting data back. Feel free to
                explore "under the hood" in the functions in _lib/

                Good luck!
            */
            await challenge1();
            await challenge2();
            await challenge3();
        }

        // TODO: Next it maks sense to go swap out ArasakaServerConnection for a generic 
        // ServerConnection object that we can use and pass in either Arasaka or Militech to determine
        // which it will be. We already have the MilitechMessage classes in `_HttpResponseModels.cs`
        /*
            1. Genericize the ArasakaServerConnection to be ServerConnection<T>
            2. Genericize the KuangMalwareFamily so it's not using any of the Arasaka stuff
            
        */

        public static async Task challenge1() {
            /*
                TODO: Objective: We already have instantiation of the Arasaka and Militech variants of the
                malware and the Initialization. Both of the variants have their own Server Connections. This
                needs to be genericized, meaning that we need to go create some generic code to handle this.
                Right now for this challenge we only care about genericizing the ServerConnection because
                we're gonna do more genericizing later.
                    1. Use F12 on the arasakaIceBreaker's `Initialize()` method. Find more info there! 
            */
            ArasakaKuangPrimusMalware arasakaIceBreaker = new ArasakaKuangPrimusMalware();
            await arasakaIceBreaker.Initialize();

            MilitechKuangPrimusMalware militechIceBreaker = new MilitechKuangPrimusMalware();
            await militechIceBreaker.Initialize();
        }

        public static async Task challenge2() {
            // FIXME: Mentor note
            // Make a generic `MultiKuangMalwareFamily`

            ArasakaKuangPrimusMalware arasakaIceBreaker = new ArasakaKuangPrimusMalware();
            await arasakaIceBreaker.Initialize();

            /*
            TODO: Objective: 
            */
            List<ArasakaMessageProcessList> arasakaProcessList = await arasakaIceBreaker.GetArasakaProcessList();
            IEnumerable<string> arasakaMemoryMapping = await arasakaIceBreaker.GetProcessMemoryMapping();

            MilitechKuangPrimusMalware militechIceBreaker = new MilitechKuangPrimusMalware();
            await militechIceBreaker.Initialize();
            List<MilitechICEProcessList> militechProcessLists = await militechIceBreaker.GetMilitechProcessList();
            IEnumerable<string> militechMemoryMapping = await militechIceBreaker.GetProcessMemoryMapping();
        }

        public static async Task challenge3() {
            // FIXME: Mentor note
            // Need to create a new class, simply the MultiKuangPrimusMalware.cs, which is genericized
            // from the existing Arasaka and Militech variants.

            MultiKuangPrimusMalware<ArasakaMessageRoot, ArasakaMessageProcessList> arasakaIceBreaker = new MultiKuangPrimusMalware<ArasakaMessageRoot, ArasakaMessageProcessList>();
            await arasakaIceBreaker.Initialize();
            List<ArasakaMessageProcessList> arasakaMessageProcessList = await arasakaIceBreaker.GetProcessList();
            IEnumerable<string> arasakaMemoryMapping = await arasakaIceBreaker.GetProcessMemoryMapping();

            MultiKuangPrimusMalware<MilitechMessageRoot, MilitechICEProcessList> militechIceBreaker = new MultiKuangPrimusMalware<MilitechMessageRoot, MilitechICEProcessList>();
            await militechIceBreaker.Initialize();
            List<MilitechICEProcessList> militechICEProcessLists = await militechIceBreaker.GetProcessList();
            IEnumerable<string> militechMemoryMapping = await militechIceBreaker.GetProcessMemoryMapping();
        }
    }
}