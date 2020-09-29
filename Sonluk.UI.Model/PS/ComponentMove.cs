using Sonluk.UI.Model.PS.ComponentMoveService;
using Sonluk.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.UI.Model.PS
{
    public class ComponentMove
    {
        private ComponentMoveSoapClient client = new ComponentMoveSoapClient("ComponentMoveSoap", AppConfig.Settings("RemoteAddress") + "PS/ComponentMove.asmx");
        public PS_ZPSFUG_Q_CGDS Component_DSXX(string I_NPLNR, string ptoken)
        {
            return client.Component_DSXX(I_NPLNR, ptoken);
        }

        public string Component_ljds(ZSL_PSS_INC_CGDS i_in, string ptoken)
        {
            return client.Component_ljds(i_in, ptoken);
        }


        public ComponentCM[] ComponentCM_GET(string IV_VERIF, string ptoken)
        {
            return client.ComponentCM_GET(IV_VERIF, ptoken);
        }

        public string ComponentPutAway(PS_componentputaway ps_componentputaway, string ptoken)
        {
            return client.ComponentPutAway(ps_componentputaway, ptoken);
        }

        public PS_ZPSFUG_Q_CMCC ComponentInventory_CM(string I_VERIF, string ptoken)
        {
            return client.ComponentInventory_CM(I_VERIF, ptoken);
        }

        public PS_ZPSFUG_Q_WLCC ComponentInventory_Network(string I_AUFNR, string ptoken)
        {
            return client.ComponentInventory_Network(I_AUFNR, ptoken);
        }

        public PS_ZPSFUG_Q_LJXJ ComponentSoldout_read(string I_SENUM, string I_ZROWSNUM, string ptoken)
        {
            return client.ComponentSoldout_read(I_SENUM, I_ZROWSNUM, ptoken);
        }

        public PS_MSG ComponentSoldout(ZSL_PSS_INC_LJXJ ps_i, string ptoken)
        {
            return client.ComponentSoldout(ps_i, ptoken);
        }

        public PS_MSG ComponentMoving_all(ZSL_PSS_INC_LJYC i_in, string ptoken)
        {
            return client.ComponentMoving_all(i_in, ptoken);
        }
    }
}
