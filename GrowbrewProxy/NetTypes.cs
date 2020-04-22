using System;

namespace GrowbrewProxy
{
	// Token: 0x0200000B RID: 11
	public class NetTypes
	{
		// Token: 0x0200000C RID: 12
		public enum PacketTypes
		{
			// Token: 0x040000B8 RID: 184
			PLAYER_LOGIC_UPDATE,
			// Token: 0x040000B9 RID: 185
			CALL_FUNCTION,
			// Token: 0x040000BA RID: 186
			UPDATE_STATUS,
			// Token: 0x040000BB RID: 187
			TILE_CHANGE_REQ,
			// Token: 0x040000BC RID: 188
			LOAD_MAP,
			// Token: 0x040000BD RID: 189
			TILE_EXTRA,
			// Token: 0x040000BE RID: 190
			TILE_EXTRA_MULTI,
			// Token: 0x040000BF RID: 191
			TILE_ACTIVATE,
			// Token: 0x040000C0 RID: 192
			APPLY_DMG,
			// Token: 0x040000C1 RID: 193
			INVENTORY_STATE,
			// Token: 0x040000C2 RID: 194
			ITEM_ACTIVATE,
			// Token: 0x040000C3 RID: 195
			ITEM_ACTIVATE_OBJ,
			// Token: 0x040000C4 RID: 196
			UPDATE_TREE,
			// Token: 0x040000C5 RID: 197
			MODIFY_INVENTORY_ITEM,
			// Token: 0x040000C6 RID: 198
			MODIFY_ITEM_OBJ,
			// Token: 0x040000C7 RID: 199
			APPLY_LOCK,
			// Token: 0x040000C8 RID: 200
			UPDATE_ITEMS_DATA,
			// Token: 0x040000C9 RID: 201
			PARTICLE_EFF,
			// Token: 0x040000CA RID: 202
			ICON_STATE,
			// Token: 0x040000CB RID: 203
			ITEM_EFF,
			// Token: 0x040000CC RID: 204
			SET_CHARACTER_STATE,
			// Token: 0x040000CD RID: 205
			PING_REPLY,
			// Token: 0x040000CE RID: 206
			PING_REQ,
			// Token: 0x040000CF RID: 207
			PLAYER_HIT,
			// Token: 0x040000D0 RID: 208
			APP_CHECK_RESPONSE,
			// Token: 0x040000D1 RID: 209
			APP_INTEGRITY_FAIL,
			// Token: 0x040000D2 RID: 210
			DISCONNECT,
			// Token: 0x040000D3 RID: 211
			BATTLE_JOIN,
			// Token: 0x040000D4 RID: 212
			BATTLE_EVENT,
			// Token: 0x040000D5 RID: 213
			USE_DOOR,
			// Token: 0x040000D6 RID: 214
			PARENTAL_MSG,
			// Token: 0x040000D7 RID: 215
			GONE_FISHIN,
			// Token: 0x040000D8 RID: 216
			STEAM,
			// Token: 0x040000D9 RID: 217
			PET_BATTLE,
			// Token: 0x040000DA RID: 218
			NPC,
			// Token: 0x040000DB RID: 219
			SPECIAL,
			// Token: 0x040000DC RID: 220
			PARTICLE_EFFECT_V2,
			// Token: 0x040000DD RID: 221
			ARROW_TO_ITEM,
			// Token: 0x040000DE RID: 222
			TILE_INDEX_SELECTION,
			// Token: 0x040000DF RID: 223
			ADDITIONAL_SEQUENCE
		}

		// Token: 0x0200000D RID: 13
		public enum NetMessages
		{
			// Token: 0x040000E1 RID: 225
			UNKNOWN,
			// Token: 0x040000E2 RID: 226
			SERVER_HELLO,
			// Token: 0x040000E3 RID: 227
			GENERIC_TEXT,
			// Token: 0x040000E4 RID: 228
			GAME_MESSAGE,
			// Token: 0x040000E5 RID: 229
			GAME_PACKET,
			// Token: 0x040000E6 RID: 230
			ERROR,
			// Token: 0x040000E7 RID: 231
			TRACK,
			// Token: 0x040000E8 RID: 232
			LOG_REQ,
			// Token: 0x040000E9 RID: 233
			LOG_RES
		}
	}
}
