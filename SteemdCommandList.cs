using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SteemAPI
{
    public class SteemdCommandList
    {
        public static  SteemdCommand[] steemdCommandList = new SteemdCommand[]{
            new SteemdCommand(0,"","",null),
            /*Tags*/
            new SteemdCommand(1,"get_trending_tags","Liste angesagter Schlagworte",new ArrayList(){"ski",2}),
			new SteemdCommand(2,"get_tags_used_by_author","Liefert kein Ergebnis",new ArrayList(){"realtom"}),
			new SteemdCommand(3,"get_discussions_by_payout","Methode kann nicht gefunden werden",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
			new SteemdCommand(4,"get_post_discussions_by_payout","Liste von Postings nach Auszahlung",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
			new SteemdCommand(5,"get_comment_discussions_by_payout","Liste von Kommentaren nach Auszahlung",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
			new SteemdCommand(6,"get_discussions_by_trending","Liste von Postings in Trending",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
            new SteemdCommand(7,"get_discussions_by_created","Liste von Postings nach Aktualität",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
			new SteemdCommand(8,"get_discussions_by_active","Liste aktiver Postings",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
			new SteemdCommand(9,"get_discussions_by_cashout","Liste von Postings mit ausstehenden Auszahlungen",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
			new SteemdCommand(10,"get_discussions_by_votes","Liste von Postings nach Stimmen",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
			new SteemdCommand(11,"get_discussions_by_children","Liste untergeordneter Postings",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
			new SteemdCommand(12,"get_discussions_by_hot","Liste von Postings in Hot",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
			new SteemdCommand(13,"get_discussions_by_feed","Liste von Postings eines Feeds",new ArrayList(){"{\"tag\":\"realtom\",\"limit\":2}"}),
			new SteemdCommand(14,"get_discussions_by_blog","Liste von Postings eines Blogs",new ArrayList(){"{\"tag\":\"realtom\",\"limit\":2}"}),
			new SteemdCommand(15,"get_discussions_by_comments","Liste von Kommentaren eines Benutzers",new ArrayList(){"{\"start_author\":\"realtom\",\"start_permlink\":\"skitour-auf-den-blahstein\",\"limit\":2}"}),
			new SteemdCommand(16,"get_discussions_by_promoted","Liste von Postings in Promoted",new ArrayList(){"{\"tag\":\"ski\",\"limit\":2}"}),
            /*Blocks and transactions*/
			new SteemdCommand(17,"get_block_header","Infos zum Kopf des Blocks",new ArrayList(){500}),
            new SteemdCommand(18,"get_block","Infos zum Block",new ArrayList(){500}),
			new SteemdCommand(19,"get_ops_in_block","Operationen eines Blocks",new ArrayList(){500,"false"}),
            new SteemdCommand(20,"get_state","Status des Netzwerks",new ArrayList(){""}),
            /*Globals*/
			new SteemdCommand(21,"get_config","Interne Blockchain Konfiguration",null),
			new SteemdCommand(22,"get_dynamic_global_properties","Aktueller Blockchain Status",null),
			new SteemdCommand(23,"get_chain_properties","Blockchain Eigenschaften",null),
			new SteemdCommand(24,"get_feed_history","Stündlicher durchschnittlicher Preisverlauf",null),
			new SteemdCommand(25,"get_current_median_history_price","Aktueller durchschnittlicher Preis",null),
			new SteemdCommand(26,"get_witness_schedule","Zeugenverlauf",null),
            new SteemdCommand(27,"get_hardfork_version","Hardfork Version",null),
			new SteemdCommand(28,"get_next_scheduled_hardfork","Hardfork Version und Aktivierungszeitpunkt",null),
			new SteemdCommand(29,"get_reward_fund","Infos über Posting Belohnungen",new ArrayList(){"post"}),
            /*Keys*/
            new SteemdCommand(30,"get_key_references","Liefert Benutzernamen",new ArrayList(){new ArrayList(){"STM7dbLLaztTttWvRdVb1NdjdboieZcMsnavAwJzaStxUTKkSnDnK"}}),
            /*Accounts*/
            new SteemdCommand(31,"get_accounts","Infos zu Konten",new ArrayList(){new ArrayList(){"realtom"}}),
			new SteemdCommand(32,"get_account_references","Muss für Steem überarbeitet werden",new ArrayList(){338882}),
			new SteemdCommand(33,"lookup_account_names","Infos zu Konten",new ArrayList(){new ArrayList(){"realtom","gtg"}}),
			new SteemdCommand(34,"lookup_accounts","Suche Benutzer",new ArrayList(){"realtom",2}),
            new SteemdCommand(35,"get_account_count","Anzahl der Konten",null),
			new SteemdCommand(36,"get_conversion_requests","Liefert kein Ergebnis",new ArrayList(){"realtom"}),
			new SteemdCommand(37,"get_account_history","Verlauf eines Kontos",new ArrayList(){"realtom",-1,2}),
			new SteemdCommand(38,"get_owner_history","Besitzerverlauf",new ArrayList(){"realtom"}),
			new SteemdCommand(39,"get_recovery_request","Kontostatus",new ArrayList(){"realtom"}),
			new SteemdCommand(40,"get_escrow","Liefert null",new ArrayList(){"realtom",1}),
			new SteemdCommand(41,"get_withdraw_routes","Liefert kein Ergebnis",new ArrayList(){"realtom","all"}),
			new SteemdCommand(42,"get_account_bandwidth","Bandbreite für Posting oder Handel",new ArrayList(){"realtom",1}),
			new SteemdCommand(43,"get_savings_withdraw_from","Liefert kein Ergebnis",new ArrayList(){"realtom"}),
			new SteemdCommand(44,"get_savings_withdraw_to","Liefert kein Ergebnis",new ArrayList(){"realtom"}),
			new SteemdCommand(45,"get_vesting_delegations","Deligierte VESTS",new ArrayList(){"realtom","",2}),
			new SteemdCommand(46,"get_expiring_vesting_delegations","Liefert kein Ergebnis",new ArrayList(){"realtom","2018-03-01T00:00:00",2}),
            /*Market*/
			new SteemdCommand(47,"get_order_book","Liste von Kauf- und Verkaufsangeboten des internen STEEM Marktes",new ArrayList(){2}),
			new SteemdCommand(48,"get_open_orders","Offene Transaktionen",new ArrayList(){"realtom"}),
			new SteemdCommand(49,"get_liquidity_queue","Methode kann nicht gefunden werden",new ArrayList(){"realtom",2}),
            /*Authority and validation*/
			new SteemdCommand(50,"get_transaction_hex","Nicht implementiert",null),
			new SteemdCommand(51,"get_transaction","Nicht implementiert",null),
            new SteemdCommand(52,"get_required_signatures","Nicht implementiert",null),
            new SteemdCommand(53,"get_potential_signatures","Nicht implementiert",null),
            new SteemdCommand(54,"verify_authority","Nicht implementiert",null),
			new SteemdCommand(55,"verify_account_authority","Nicht implementiert",null),
            /*Votes*/
			new SteemdCommand(56,"get_active_votes","Stimmen für Posting",new ArrayList(){"realtom","skitour-auf-den-blahstein"}),
			new SteemdCommand(57,"get_account_votes","Abgegebene Stimmen eines Kontos",new ArrayList(){"realtom"}),
            /*Content*/
			new SteemdCommand(58,"get_content","Infos über Posting",new ArrayList(){"realtom","skitour-auf-den-blahstein"}),
			new SteemdCommand(59,"get_content_replies","Liste der Antworten auf Posting",new ArrayList(){"realtom","skitour-auf-den-blahstein"}),
			new SteemdCommand(60,"get_discussions_by_author_before_date","Diskussionen von Permalink vor Zeitpunkt",new ArrayList(){"realtom","skitour-auf-den-blahstein","2018-03-01T00:00:00",2}),
			new SteemdCommand(61,"get_replies_by_last_update","Antworten von einem Permalink beginnend",new ArrayList(){"realtom","skitour-auf-den-blahstein",2}),
            /*Witness*/
			new SteemdCommand(62,"get_witnesses","Zeugen nach IDs",new ArrayList(){new ArrayList(){7,8}}),
			new SteemdCommand(63,"get_witness_by_account","Zeuge nach Benutzername",new ArrayList(){"gtg"}),
			new SteemdCommand(64,"get_witnesses_by_vote","Zeugen nach Anzahl der Stimmen",new ArrayList(){"gtg",2}),
			new SteemdCommand(65,"lookup_witness_accounts","Liste der Zeugen",new ArrayList(){"gtg",2}),
			new SteemdCommand(66,"get_witness_count","Anzahl der Zeugen",null),
            new SteemdCommand(67,"get_active_witnesses","Liste der aktiven Zeugen",null)
        };

        public static SteemdCommand GetSteemdCommandByID(int id)
        {
            if (id < steemdCommandList.Length) return steemdCommandList[id];
            else return null;
        }
    }
}
