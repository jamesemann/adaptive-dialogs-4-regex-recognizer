using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Adaptive;
using Microsoft.Bot.Builder.Dialogs.Debugging;
using Microsoft.Bot.Builder.Dialogs.Declarative;
using Microsoft.Bot.Builder.Dialogs.Declarative.Resources;
using System.Threading;
using System.Threading.Tasks;

namespace adaptive_dialogs_4
{
    public class AdaptiveBot : ActivityHandler
    {
        private ResourceExplorer resourceExplorer;
        private DialogManager dialogManager;

        public AdaptiveBot(ResourceExplorer resourceExplorer)
        {
            this.resourceExplorer = resourceExplorer;

            void LoadRootDialog()
            {
                var root = this.resourceExplorer.GetResource("regexRecognizerDemo.dialog");
                this.dialogManager = new DialogManager(DeclarativeTypeLoader.Load<AdaptiveDialog>(root, resourceExplorer, DebugSupport.SourceMap));
            }

            LoadRootDialog();
        }

        public async override Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            await dialogManager.OnTurnAsync(turnContext, cancellationToken);
        }
    }
}
