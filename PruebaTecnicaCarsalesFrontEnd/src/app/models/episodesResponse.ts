import { Episode } from "./episode";
import { PageInfo } from "./pageInfo";

export interface EpisodesResponse {
  info: PageInfo;
  results: Episode[];
}
