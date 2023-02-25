# HybridP2P

Honestly, the odds that I expect this to go any further than my other projects (i.e. nowhere) is basically zero. But, in the unlikely case I actually follow through with making this...

HybridP2P has probably already been implemented somehow in some regard. I don't look up if things exist already before I decide to make them because I don't make them for the sake of being useful, I make them for the joy of making them.

HybridP2P is short for Hybrid Peer-to-Peer. I've always thought P2P was going to be the future except that Security was a huge concern. But, I thought, that could be solved "simply" with some light central authority, authentication, and validation. Thus: Hybrid.

## Central Authority

The Central Authority is the single-instance central authority (hence its name) of all active CDNAs. The Central Authority's purpose is to coordinate the spin-up and spin-down of CDNA nodes and to tell ClientHosts what CDNAs exist that it can connect to.

The Central Authority manages ClientHost authentication as well. A ClientHost must authenticate with the CentralAuthority before it is able to connect to the CDNA nodes. 

## Content Delivery Network Authority (CDNA)

CDNAs are semi-central that serve and verify Content (e.g. Files). When a CDNA is turned on, it verifies with the Central Authority that it has come online, and after that the Central Authority will include the CDNA node in its list of active nodes, and Client Hosts will be allowed to ping it to measure latency.

A CDNA is also responsible for propagating files that are uploaded to it (and checked for malware and such) to other CDNAs for distribution. It also keeps track of who has what sharable to power P2P coordination.

## Client Host

A Client Host is the program running on a client's machine. It must authenticate with a Central Authority before being allowed to share Content that it has previous downloaded from a CDNA and before being allowed to upload Content to the CDNA Network.