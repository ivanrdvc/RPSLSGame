import Layout from "@/components/common/Layout";
import Game from "@/components/game/Game";

import { Box, Container, Heading } from "@chakra-ui/react";

const Home = () => {
  return (
    <Layout>
      <Container maxW="container.xl">
        <Box py={[5, 5, null, 10]}>
          <Heading>Rock Paper Scissors Lizard Spock Game</Heading>
        </Box>
        <Game />
      </Container>
    </Layout>
  );
};

export default Home;
