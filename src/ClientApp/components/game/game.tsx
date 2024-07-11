import { Box, Button, Spinner, Text } from "@chakra-ui/react";
import useGame from "@/hooks/useGame";

const Game = () => {
  const { choices, choicesError, result, loadingPlay, playError, handleChoiceClick } = useGame();

  if (choicesError) {
    return <Text color="red.500">Error loading choices.</Text>;
  }

  if (!choices) {
    return <Spinner />;
  }

  return (
    <Box>
      {choices.map((choice) => (
        <Button
          key={choice.id}
          onClick={() => handleChoiceClick(choice.id)}
          p={4}
          borderWidth="1px"
          borderRadius="lg"
          m={2}
        >
          {choice.name}
        </Button>
      ))}

      {loadingPlay && (
        <Box p="4">
          <Spinner />
        </Box>
      )}

      {playError && <Text color="red.500">Error: {playError}</Text>}

      {result && (
        <Box mt={4}>
          <Text>{result.results === "win" ? "You win!" : result.results === "lose" ? "You lose!" : "It's a tie!"}</Text>
          <Text>Player choice: {result.player}</Text>
          <Text>Computer choice: {result.computer}</Text>
        </Box>
      )}
    </Box>
  );
};

export default Game;
